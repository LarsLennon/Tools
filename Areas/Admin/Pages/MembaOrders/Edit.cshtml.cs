using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.MembaOrders
{
    public class EditModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public EditModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembaOrder MembaOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembaOrder = await _context.MembaOrders
                //.Include(m => m.CreatedByMember)
                .Include(m => m.Member)
                .Include(m => m.Section)
                .Include(m => m.Team).FirstOrDefaultAsync(m => m.MembaOrderId == id);

            if (MembaOrder == null)
            {
                return NotFound();
            }
           ViewData["CreatedByMemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
           ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
           ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionId");
           ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MembaOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembaOrderExists(MembaOrder.MembaOrderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MembaOrderExists(int id)
        {
            return _context.MembaOrders.Any(e => e.MembaOrderId == id);
        }
    }
}
