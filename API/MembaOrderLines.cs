using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToolSmukfest.API
{
    [Route("~/api/[controller]")]
    [ApiController]
    public class MembaOrderLines : ControllerBase
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public MembaOrderLines(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //Create instance of Linq-To-Sql class as db  
        //ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/<MembaOrderLines>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var collection = _applicationDbContext.MembaOrderLines.ToList();

            String[] mylist = collection.Select(I => Convert.ToString(I.Product)).ToArray();

            return mylist;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<MembaOrderLines>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {

            var item = _applicationDbContext.MembaOrderLines.SingleOrDefault(m => m.MembaOrderLineId == id);
            //_applicationDbContext.MembaOrderLines.Remove(item);
            //_applicationDbContext.SaveChanges();
            //var line = _applicationDbContext.MembaOrderLines.SingleOrDefault(m => m.MembaOrderLineId == id);
            if (item != null)
            {
                return item.Product + " " + item.Amount + " " + item.From + " " + item.To;
            }
            return "";
        }
        // POST api/<MembaOrderLines>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MembaOrderLines>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MembaOrderLines>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _applicationDbContext.MembaOrderLines.SingleOrDefault(m => m.MembaOrderLineId == id);
            _applicationDbContext.MembaOrderLines.Remove(item);
            _applicationDbContext.SaveChanges();
        }
    }
}
