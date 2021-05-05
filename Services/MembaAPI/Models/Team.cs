using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Services.MembaAPI.Models
{
    public class Team
    {
        public string TeamNumber { get; set; }
        public int TeamId { get; set; }
        public int? TeamParentId { get; set; }
        public string TeamName { get; set; }
        public bool IsGroup { get; set; }
        public int SeasonId { get; set; }
        public int CopyOfTeamId { get; set; }
        public object BudgetNumber { get; set; }
    }
}
