using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Services.MembaAPI.Models;

namespace ToolSmukfest.Services.MembaAPI.Responses
{
    public class GetTeamMembers
    {
        public Error Error { get; set; }
        public List<TeamMember> TeamMembers { get; set; }
    }
}
