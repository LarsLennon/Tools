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
    public class EditModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public EditModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Section Section { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Section = await _context.Section.FirstOrDefaultAsync(m => m.SectionId == id);

            if (Section == null)
            {
                return NotFound();
            }
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

            _context.Attach(Section).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SectionExists(Section.SectionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("/Section/Details", new { area = "Admin", id = Section.FestivalId });
        }

        private bool SectionExists(int id)
        {
            return _context.Section.Any(e => e.SectionId == id);
        }
    }
}
