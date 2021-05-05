using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Services.MembaAPI.Models;

namespace ToolSmukfest.Services.MembaAPI.Responses
{
    // get /Api/MemberApi/1/GetTeams
    public class GetTeams
    {
        public Error Error { get; set; }
        public List<Team> Teams { get; set; }
    }
}
