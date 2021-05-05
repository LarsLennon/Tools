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

namespace ToolSmukfest.Areas.Admin.Pages.MembaOrderLines
{
    public class EditModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public EditModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MembaOrderLine MembaOrderLine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembaOrderLine = await _context.MembaOrderLines
                .Include(m => m.ItemType).FirstOrDefaultAsync(m => m.MembaOrderLineId == id);

            if (MembaOrderLine == null)
            {
                return NotFound();
            }
           ViewData["ItemTypeId"] = new SelectList(_context.ItemType, "ItemTypeId", "ItemTypeId");
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

            _context.Attach(MembaOrderLine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MembaOrderLineExists(MembaOrderLine.MembaOrderLineId))
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

        private bool MembaOrderLineExists(int id)
        {
            return _context.MembaOrderLines.Any(e => e.MembaOrderLineId == id);
        }
    }
}
