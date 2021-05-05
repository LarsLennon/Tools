using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class ItemType
    {
        public enum PricePerUnit
        {
            Undefined = 0,
            Day = 1,
            Hour = 2
        }

        public int ItemTypeId { get; set; }



        public string Title { get; set; }
        public string ShortTitle { get; set; }
        public string MembaTextMatch { get; set; }


        public bool ExternalSupplier { get; set; }


        public int Price { get; set; }
        public PricePerUnit PricePeriodUnit { get; set; }


        public int SectionId { get; set; }
        public virtual Section Section { get; set; }


        public int? ItemTypeCategoryId { get; set; }
        public virtual ItemTypeCategory ItemTypeCategory { get; set; }

        public int? ItemSupplierId { get; set; }
        public virtual ItemSupplier ItemSupplier { get; set; }
    }
}
