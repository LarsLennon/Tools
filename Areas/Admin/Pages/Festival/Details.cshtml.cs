using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Festivals
{
    public class DetailsModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DetailsModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Festival Festival { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                //return NotFound();
                return RedirectToPage("/Error", new { area = "", id = 2 });
            }

            Festival = await _context.Festival
                .Include(f => f.Sections)
                .FirstOrDefaultAsync(m => m.FestivalId == id);

            if (Festival == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
