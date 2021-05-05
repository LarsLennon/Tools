using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class MembaOrderLine
    {
        public int MembaOrderLineId { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public string Product { get; set; }
        public int Amount { get; set; }
        //public string RawMembaInput { get; set; }

        public int ItemTypeId { get; set; }
        [ForeignKey("ItemTypeId")]
        public virtual ItemType ItemType { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
