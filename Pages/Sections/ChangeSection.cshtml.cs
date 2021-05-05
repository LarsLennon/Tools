using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;

namespace ToolSmukfest.Pages.Sections
{
    public class ChangeSectionModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public ChangeSectionModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members.ToListAsync();
        }
    }
}
