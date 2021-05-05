using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Section
    {
        public int SectionId { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public int FestivalId { get; set; }
        public virtual Festival Festival { get; set; }

        public virtual ICollection<ItemSupplier> ItemSuppliers { get; set; }
        public virtual ICollection<ItemType> ItemTypes { get; set; }
        public virtual ICollection<ItemTypeCategory> ItemTypeCategories { get; set; }
        public virtual ICollection<MembaOrder> MembaOrders { get; set; }
    }
}
