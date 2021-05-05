using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class ItemSupplier
    {
        public int ItemSupplierId { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Description { get; set; }

        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
    }
}
