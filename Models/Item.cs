using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public int Nr { get; set; }


        public DateTime? Received { get; set; }

        public DateTime? Returned { get; set; }


        public string Comment { get; set; }

        public string Registration { get; set; }


        public int ItemTypeId { get; set; }
        public virtual ItemType ItemType { get; set; }


        public int? ItemSupplierId { get; set; }
        public virtual ItemSupplier ItemSupplier { get; set; }


        public int? ReceiverMemberId { get; set; }
        public virtual Member ReceiverMember { get; set; }


        public int? ReturnerMemberId { get; set; }
        public virtual Member ReturnerMember { get; set; }


        public virtual ICollection<Booking> Bookings { get; set; }

        //public virtual ICollection<ItemImage> Images { get; set; }
    }
}
