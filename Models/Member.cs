using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberId { get; set; }


        public string Name { get; set; }
        public string MembaNumber { get; set; }
        public string Email { get; set; }
        public string EmailAlternate { get; set; }
        public DateTime? Birthday { get; set; }


        public int? CurrentSectionId { get; set; }

        public bool VirtualMember { get; set; } // True if member is created locally and not existing in Memba


        public DateTime? LastSynchronization { get; set; }


        public virtual ICollection<Item> ItemsReceived { get; set; }
        public virtual ICollection<Item> ItemsReturned { get; set; }

        public virtual ICollection<MembaOrder> MembaOrders { get; set; }
        public virtual ICollection<MembaOrder> MembaOrdersCreated { get; set; }

    }
}
