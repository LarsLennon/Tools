using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Teams
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
        ViewData["ParentId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return Page();
        }

        [BindProperty]
        public Team Team { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Teams.Add(Team);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
