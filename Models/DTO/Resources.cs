using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models.DTO
{
    public class Resources
    {
        public int id { get; set; }
        public string title { get; set; }
        public string status { get; set; }
        public string eventColor { get; set; }
    }
    public class EventResources
    {
        public int id { get; set; }
        public string title { get; set; }
        public int resourceId { get; set; }
        public string start { get; set; }
        public string end { get; set; }

    }
}
