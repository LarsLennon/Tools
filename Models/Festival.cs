using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Festival
    {
        public int FestivalId { get; set; }

        public string Title { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
