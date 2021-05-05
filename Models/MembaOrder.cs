using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class MembaOrder
    {
        public int MembaOrderId { get; set; }


        public int OrderNo { get; set; }
        public DateTime? Created { get; set; }
        public string Comment { get; set; }


        public int? TeamId { get; set; }
        public virtual Team Team { get; set; }

        //[Key, ForeignKey("Member"), Column(Order = 1)]
        public int? MemberId { get; set; }
        [ForeignKey("MemberId")]
        [InverseProperty("MembaOrders")]
        public virtual Member Member { get; set; }


        //[Key, ForeignKey("CreatedByMember"), Column(Order = 2)]
        public int? CreatedByMemberId { get; set; }
        [ForeignKey("CreatedByMemberId")]
        [InverseProperty("MembaOrdersCreated")]
        public virtual Member CreatedByMember { get; set; }
        

        public int? SectionId { get; set; }
        public virtual Section Section { get; set; }


        public virtual ICollection<MembaOrderLine> Lines { get; set; }
    }
}
