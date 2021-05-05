using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.MembaOrders
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
        ViewData["CreatedByMemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
        ViewData["MemberId"] = new SelectList(_context.Members, "MemberId", "MemberId");
        ViewData["SectionId"] = new SelectList(_context.Section, "SectionId", "SectionId");
        ViewData["TeamId"] = new SelectList(_context.Teams, "TeamId", "TeamId");
            return Page();
        }

        [BindProperty]
        public MembaOrder MembaOrder { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MembaOrders.Add(MembaOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
