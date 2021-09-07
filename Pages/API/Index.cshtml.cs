using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolSmukfest.Data;

namespace ToolSmukfest.Pages.API
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _applicationDbContext;

        public IndexModel(ApplicationDbContext context)
        {
            _applicationDbContext = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var collection = _applicationDbContext.MembaOrderLines.ToList();

            String[] mylist = collection.Select(I => Convert.ToString(I.Product)).ToArray();

            return mylist;
        }
        //public void OnGet()
        //{
        //    var collection = _applicationDbContext.MembaOrderLines.ToList();

        //    String[] mylist = collection.Select(I => Convert.ToString(I.Product)).ToArray();

        //    return mylist;
        //}
    }
}
