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

namespace ToolSmukfest.Areas.Admin.Pages.Sections
{
    public class CreateModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public CreateModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? festivalId)
        {
            if (festivalId == null)
            {
                return NotFound("No Id provided.");
            }

            var Festival = _context.Festival
                .FirstOrDefault(m => m.FestivalId == festivalId);

            if (Festival == null)
            {
                return NotFound("Festival not found");
            }

            ViewData["festivalName"] = Festival.Title;
            ViewData["festivalId"] = festivalId;

            return Page();
        }

        [BindProperty]
        public Section Section { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Section.Add(Section);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Festival/Details", new { area = "Admin", id = Section.FestivalId });
        }
    }
}
