using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolSmukfest.Data;
using ToolSmukfest.Models;
using static ToolSmukfest.Models.ItemType;

namespace ToolSmukfest.Areas.Admin.Pages.ItemTypes
{
    public class CreateModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public CreateModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ItemSupplierId"] = new SelectList(_context.Set<ItemSupplier>(), "ItemSupplierId", "Name");
            ViewData["ItemTypeCategoryId"] = new SelectList(_context.Set<ItemTypeCategory>(), "ItemTypeCategoryId", "Title");
            ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "Title");
            ViewData["PricePerUnit"] = new SelectList(Enum.GetValues(typeof(PricePerUnit)));
            
            return Page();
        }

        [BindProperty]
        public ItemType ItemType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ItemType.Add(ItemType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Create", new { sectionId = ItemType.SectionId });
        }
    }
}
