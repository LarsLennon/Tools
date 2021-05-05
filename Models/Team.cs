using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Team
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamId { get; set; }


        public string Name { get; set; }
        public string Number { get; set; }
        public bool IsGroup { get; set; }


        public DateTime? LastSynchronization { get; set; }


        public int? ParentId { get; set; }
        public virtual Team Parent { get; set; }



        public virtual ICollection<Team> Children { get; set; }
        public virtual ICollection<MembaOrder> MembaOrders { get; set; }
    }
}
