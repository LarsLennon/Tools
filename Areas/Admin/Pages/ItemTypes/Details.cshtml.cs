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
    public class DetailsModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DetailsModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
