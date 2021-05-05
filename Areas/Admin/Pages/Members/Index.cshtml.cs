using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Data;
using ToolSmukfest.Models;
using ToolSmukfest.Models.DTO;

namespace ToolSmukfest.Areas.Admin.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public IndexModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Member> Member { get;set; }

        public async Task OnGetAsync()
        {
            Member = await _context.Members.ToListAsync();
        }

        public async Task<IActionResult> GetPaggedCrewData(int pageSize = 20, int pageNumber = 1, string searchString = "")
        {
            List<Member> listData;
            int PageSize = pageSize;

            if (searchString != null && searchString != "")
            {
                listData = await _context.Members.OrderBy(n => n.Name).Where(x => x.Name.Contains(searchString)).ToListAsync();
                PageSize = 0;
            }
            else
            {
                listData = await _context.Members.OrderBy(n => n.Name).ToListAsync();

            }

            var pList = new PageList<Member>(listData, pageNumber, PageSize);
            return Partial("_ListTable", pList);
        }
    }
}
