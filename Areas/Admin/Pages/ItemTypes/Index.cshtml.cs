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
    public class IndexModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public IndexModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ItemType> ItemType { get;set; }

        public async Task<IActionResult> OnGetAsync(int? sectionId)
        {
            if (sectionId == null)
            {
                return NotFound("No Section Id provided.");
            }


            var Section = await _context.Section
                .Include(s => s.Festival)
                .FirstOrDefaultAsync(m => m.SectionId == sectionId);

            if (Section == null)
            {
                return NotFound();
            }

            ViewData["sectionTitle"] = Section.Title;
            ViewData["sectionId"] = sectionId;
            ViewData["festivalTitle"] = Section.Festival.Title;
            ViewData["festivalId"] = Section.FestivalId;

            ItemType = await _context.ItemType
                .Include(i => i.ItemSupplier)
                .Include(i => i.ItemTypeCategory)
                .Include(i => i.Section)
                .Where(s => s.SectionId == sectionId)
                .ToListAsync();

            return Page();
        }
    }
}
