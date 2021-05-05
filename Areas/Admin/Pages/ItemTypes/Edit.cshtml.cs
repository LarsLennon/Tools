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

namespace ToolSmukfest.Areas.Admin.Pages.ItemTypes
{
    public class EditModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public EditModel(ToolSmukfest.Data.ApplicationDbContext context)
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
            ViewData["ItemSupplierId"] = new SelectList(_context.Set<ItemSupplier>(), "ItemSupplierId", "ItemSupplierId");
            ViewData["ItemTypeCategoryId"] = new SelectList(_context.Set<ItemTypeCategory>(), "ItemTypeCategoryId", "ItemTypeCategoryId");
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "Title");
            ViewData["PricePerUnit"] = new SelectList(Enum.GetValues(typeof(ItemType.PricePerUnit)));
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

            _context.Attach(ItemType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemTypeExists(ItemType.ItemTypeId))
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

        private bool ItemTypeExists(int id)
        {
            return _context.ItemType.Any(e => e.ItemTypeId == id);
        }
    }
}
