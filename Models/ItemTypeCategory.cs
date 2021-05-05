using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class ItemTypeCategory
    {
        public int ItemTypeCategoryId { get; set; }


        public string Title { get; set; }


        public int SectionId { get; set; }
        public virtual Section Section { get; set; }


        public virtual ICollection<ItemType> ItemTypes { get; set; }
    }
}
