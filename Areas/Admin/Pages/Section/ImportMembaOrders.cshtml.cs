using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Sections
{
    public class ImportMembaOrdersModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        private enum MembaImport
        {
            OrderID = 0,
            Dato,
            Holdnr,
            Hold,
            Placering,
            Fra,
            Til,
            FormandNr,
            FormandFornavn,
            FormandEfternavn,
            FormandMail,
            Bestiller,
            Produkt,
            Antal,
            Status,
            Kommentar
        }

        public ImportMembaOrdersModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ToolSmukfest.Models.Section> Section { get; set; }

        public async Task OnGetAsync()
        {
            Section = await _context.Section
                .Include(s => s.Festival).ToListAsync();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(List<IFormFile> files, string Category)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string fileName = "";
            int lineCount = 0;
            int importCount = 0;
            try
            {

                _context.MembaOrderLines.RemoveRange(_context.MembaOrderLines);
                _context.MembaOrders.RemoveRange(_context.MembaOrders);
                await _context.SaveChangesAsync();

                foreach (var file in files)
                {
                    lineCount = 0;

                    using (var streamReader = new StreamReader(file.OpenReadStream()))
                    {
                        //files.FileName
                        //int linesImported = 0;
                        while (!streamReader.EndOfStream)
                        {
                            lineCount++;

                            var line = streamReader.ReadLine();
                            if (lineCount == 1) continue;
                            if (line.Length == 0) continue;
                            line = line.Replace("\"", "");
                            var data = line.Split(new[] { ';' });

                            var importValues = new Dictionary<string, string>();

                            importValues.Add("OrderID", data[(int)MembaImport.OrderID]);
                            importValues.Add("Dato", data[(int)MembaImport.Dato]);
                            importValues.Add("Holdnr", data[(int)MembaImport.Holdnr]);
                            importValues.Add("Hold", data[(int)MembaImport.Hold]);
                            importValues.Add("Placering", data[(int)MembaImport.Placering]);
                            importValues.Add("Fra", data[(int)MembaImport.Fra]);
                            importValues.Add("Til", data[(int)MembaImport.Til]);
                            importValues.Add("FormandNr", data[(int)MembaImport.FormandNr]);
                            importValues.Add("FormandFornavn", data[(int)MembaImport.FormandFornavn]);
                            importValues.Add("FormandEfternavn", data[(int)MembaImport.FormandEfternavn]);
                            importValues.Add("FormandMail", data[(int)MembaImport.FormandMail]);
                            importValues.Add("Bestiller", data[(int)MembaImport.Bestiller]);
                            importValues.Add("Produkt", data[(int)MembaImport.Produkt]);
                            importValues.Add("Antal", data[(int)MembaImport.Antal]);
                            importValues.Add("Status", data[(int)MembaImport.Status]);
                            importValues.Add("Kommentar", data[(int)MembaImport.Kommentar]);

                            int modelTypeID = FindOrCreateMembaOrder(importValues);


                            MembaOrderLine newLine = new MembaOrderLine
                            {
                                From = DateTime.Parse(data[(int)MembaImport.Fra]),
                                To = DateTime.Parse(data[(int)MembaImport.Til]),
                                Product = data[(int)MembaImport.Produkt],
                                Amount = Convert.ToInt32(data[(int)MembaImport.Antal])
                            };

                            ItemType itemType = FindItemTypeId(data[(int)MembaImport.Produkt]);
                            if (itemType == null) 
                                throw new NullReferenceException("ItemType '" + data[(int)MembaImport.Produkt] + "' not found!");

                            newLine.ItemTypeId = itemType.ItemTypeId;

                            _context.MembaOrderLines.Add(newLine);
                            await _context.SaveChangesAsync();
                            importCount++;
                        }
                    }
                }

                TempData["Message-Type"] = "success";
                TempData["Message-Content"] = "Sucessfully imported " + importCount.ToString() + " lines.";
            }
            catch (Exception exp)
            {

                TempData["Message-Type"] = "danger";
                TempData["Message-Content"] = "Could not import file. Error in line " + lineCount.ToString() + " in " + fileName + ". " + exp.Message;
                return Page();
            }

            return RedirectToPage("./Index");
        }
        private int MembaOrderNoToString(string OrderNo)
        {
            string onlyDigits = new String(OrderNo.Where(Char.IsDigit).ToArray());
            return Convert.ToInt32(onlyDigits);
        }

        private int FindOrCreateMembaOrder(Dictionary<string, string> importValues)
        {
            int orderID = MembaOrderNoToString(importValues["OrderID"]);

            MembaOrder membaOrder = _context.MembaOrders.SingleOrDefault(m => m.OrderNo == orderID);

            if (membaOrder == null)
            {

                membaOrder = new MembaOrder
                {
                    OrderNo = orderID,
                    Created = DateTime.Now,
                    Comment = importValues["Kommentar"],
                    //TeamId = 1,
                   // MemberId = 1,
                    //CreatedByMemberId = 11
                };
                
                Member formand = FindMember(importValues["FormandNr"]);
                if (formand != null)
                    membaOrder.MemberId = formand.MemberId;
                
                Member bestiller = GetBestiller(importValues["Bestiller"]);
                if (bestiller != null)
                    membaOrder.CreatedByMemberId = bestiller.MemberId;

                Team team = GetTeam(importValues["Holdnr"]);
                if (team != null)
                    membaOrder.TeamId = team.TeamId;
                    
                _context.MembaOrders.Add(membaOrder);

                _context.SaveChanges();
            }
            return membaOrder.MembaOrderId;
        }

        private Member GetBestiller(string bestiller)
        {
            Member member;
            try
            {
                int index = bestiller.IndexOf('(')+1;
                int lastIndex = bestiller.LastIndexOf(')');

                string membaNo = bestiller.Substring(index, lastIndex - index);
                member = FindMember(membaNo);
            }
            catch (Exception)
            {
                member = new Member();
            }
            return member;
        }
        private Team GetTeam(string teamNo)
        {
            Team team = _context.Teams.SingleOrDefault(m => m.Number == teamNo);
            return team;
        }
        private Member FindMember(string MembaNo)
        {
            Member member = _context.Members.SingleOrDefault(m => m.MembaNumber == MembaNo);
            return member;
        }

        private ItemType FindItemTypeId(string membaProductText)
        {
            var ItemType = _context.ItemType.SingleOrDefault(m => m.MembaTextMatch == membaProductText);

            return ItemType;
        }
    }
}
