using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Teams
{
    public class DetailsModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DetailsModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Team Team { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Team = await _context.Teams
                .Include(t => t.Parent).FirstOrDefaultAsync(m => m.TeamId == id);

            if (Team == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
