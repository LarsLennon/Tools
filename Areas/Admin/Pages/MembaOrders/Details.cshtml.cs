using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.MembaOrders
{
    public class DetailsModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public DetailsModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MembaOrder MembaOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MembaOrder = await _context.MembaOrders
                //.Include(m => m.CreatedByMember)
                .Include(m => m.Member)
                .Include(m => m.Section)
                .Include(m => m.Team).FirstOrDefaultAsync(m => m.MembaOrderId == id);

            if (MembaOrder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
