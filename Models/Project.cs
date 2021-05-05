using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Models
{
    public class Project
    {
        public int id { get; set; }
        public string title { get; set; }
        public bool iscomplete { get; set; }
    }
    public class Event
    {
        public int id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public string title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
