using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.MembaOrderLines
{
    public class DeleteModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DeleteModel(ToolSmukfest.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembaOrderLine = await _context.MembaOrderLines.FindAsync(id);

            if (MembaOrderLine != null)
            {
                _context.MembaOrderLines.Remove(MembaOrderLine);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
