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

namespace ToolSmukfest.Areas.Admin.Pages.ItemTypes
{
    public class ImportModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        private enum TypesImport
        {
            ShortTitle = 0,
            Title,
            MembaTextMatch,
            Category,
            Price,
            PricePerUnit,
        }

        public ImportModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public ToolSmukfest.Models.Section Section { get; set; }

        public async Task<IActionResult> OnGetAsync(int? sectionId)
        {
            if (sectionId == null)
            {
                return NotFound("No Section Id provided.");
            }

            Section = await _context.Section
                .Include(s => s.Festival)
                .FirstOrDefaultAsync(m => m.SectionId == sectionId);

            if (Section == null)
            {
                return NotFound();
            }
            /*
            ViewData["sectionTitle"] = Section.Title;
            ViewData["sectionId"] = sectionId;
            ViewData["festivalTitle"] = Section.Festival.Title;
            ViewData["festivalId"] = Section.FestivalId;
            */
            return Page();
        }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(List<IFormFile> files, int sectionId)
        {
            if (sectionId == null)
            {
                return NotFound("No Section Id provided.");
            }

            Section = await _context.Section
                .Include(s => s.Festival)
                .FirstOrDefaultAsync(m => m.SectionId == sectionId);

            if (Section == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            int lineCount = 0;
            int importCount = 0;
            string fileName = "";
            try
            {

                _context.ItemType.RemoveRange(_context.ItemType);
                await _context.SaveChangesAsync();

                foreach (var file in files)
                {
                    lineCount = 0;

                    using (var streamReader = new StreamReader(file.OpenReadStream()))
                    {
                        while (!streamReader.EndOfStream)
                        {
                            lineCount++;

                            var line = streamReader.ReadLine();
                            if (lineCount == 1) continue;   // Skip header
                            if (line.Length == 0) continue; // Skip empty lines
                            line = line.Replace("\"", "");
                            var data = line.Split(new[] { ';' });


                            ItemType item = new ItemType
                            {
                                SectionId = sectionId,
                                Title = data[(int)TypesImport.Title],
                                MembaTextMatch = data[(int)TypesImport.MembaTextMatch],
                                ShortTitle = data[(int)TypesImport.ShortTitle],
                                Price = Convert.ToInt32(data[(int)TypesImport.Price]),
                                PricePeriodUnit = StringToPricePerUnit(data[(int)TypesImport.PricePerUnit])
                            };

                            _context.ItemType.Add(item);
                            importCount++;
                        }
                    }
                }

            }
            catch (Exception exp)
            {

                TempData["Message-Type"] = "danger";
                TempData["Message-Content"] = "Could not parse file. Error in line " + lineCount.ToString() + " in " + fileName + ". " + exp.Message;
                return Page();
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exp)
            {

                TempData["Message-Type"] = "danger";
                TempData["Message-Content"] = "Could not save imported objects. " + exp.Message;
                return Page();
            }

            TempData["Message-Type"] = "success";
            TempData["Message-Content"] = "Sucessfully imported " + importCount.ToString() + " lines.";
            return RedirectToPage("./Index", new { sectionId = sectionId });


        }
        public ItemType.PricePerUnit StringToPricePerUnit(string PricePerUnit)
        {
            PricePerUnit = PricePerUnit.ToLower();

            switch (PricePerUnit)
            {
                case "dag":
                    return ItemType.PricePerUnit.Day;
                    break;
                case "day":
                    return ItemType.PricePerUnit.Day;
                    break;

                case "time":
                    return ItemType.PricePerUnit.Hour;
                    break;
                case "hour":
                    return ItemType.PricePerUnit.Day;
                    break;

                default:
                    break;
            }
            return ItemType.PricePerUnit.Undefined;
        }
    }
}
