using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.ItemTypes
{
    public class DeleteModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DeleteModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ItemType ItemType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ItemType = await _context.ItemType
                .Include(i => i.ItemSupplier)
                .Include(i => i.ItemTypeCategory)
                .Include(i => i.Section).FirstOrDefaultAsync(m => m.ItemTypeId == id);

            if (ItemType == null)
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

            ItemType = await _context.ItemType.FindAsync(id);

            if (ItemType != null)
            {
                _context.ItemType.Remove(ItemType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
