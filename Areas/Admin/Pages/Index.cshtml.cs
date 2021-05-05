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

namespace ToolSmukfest.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(string action)
        //public async Task<IActionResult> OnGet(string action)
        {

            var user = User;
            user.HasClaim("UserRole", "Administrator");
            var FestivalClaim = user.Claims.FirstOrDefault(c => c.Type == "Name");

            if (action == "DeleteDB" && false)
            {
                //await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM Brand");
                //await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM Category");
                //await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM Unit");
                //await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM ModelType");
                //await _context.Database.ExecuteSqlCommandAsync(@"DELETE FROM Status");
            }
            //ViewData["ModelTypeID"] = new SelectList(_context.ModelType, "ID", "ID");
            //ViewData["StatusID"] = new SelectList(_context.Status, "ID", "ID");
                       
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string action)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
