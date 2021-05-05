using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Sections
{
    public class IndexModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public IndexModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Section> Section { get;set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["FestivalId"] = id;
            Section = await _context.Section.Where(s => s.FestivalId == id).ToListAsync();

            return Page();
        }
    }
}
