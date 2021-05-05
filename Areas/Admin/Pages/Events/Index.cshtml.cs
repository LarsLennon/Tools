using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public IndexModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Events
                .Include(x => x.Project).ToListAsync();
        }
    }
}
