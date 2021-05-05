using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Pages.Shared
{
    public class ErrorMsgModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public ErrorMsgModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Festival Festival { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Festival.Add(Festival);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
