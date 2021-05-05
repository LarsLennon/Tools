using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        #region MembaOrder

        public int? MembaOrderId { get; set; }
        public virtual MembaOrder MembaOrder { get; set; }

        public int? MembaOrderLineId { get; set; }
        public virtual MembaOrderLine MembaOrderLine { get; set; }

        #endregion

        public string Comment { get; set; }
        public DateTime Created { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public DateTime? PickedUp { get; set; }
        public DateTime? Returned { get; set; }


        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }


        public int MemberId { get; set; }
        public virtual Member Member { get; set; }


        [ForeignKey("Member")]
        public int? CreatedByMemberId { get; set; }
        public virtual Member CreatedByMember { get; set; }



        public int ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
