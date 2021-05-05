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
    public class DeleteModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DeleteModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Festival Festival { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Festival = await _context.Festival.FirstOrDefaultAsync(m => m.FestivalId == id);

            if (Festival == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Festival = await _context.Festival.FindAsync(id);

            if (Festival != null)
            {
                _context.Festival.Remove(Festival);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
