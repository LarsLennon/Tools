using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Services.MembaAPI.Models;

namespace ToolSmukfest.Services.MembaAPI.Responses
{
    public class AuthenticateMember
    {
        public Error Error { get; set; }
        public bool Authenticated { get; set; }
        public int MemberId { get; set; }
        public object MemberNumber { get; set; }
        public object MemberName { get; set; }
        public int MemberPrimaryTitleId { get; set; }
        public object MemberPrimaryTitleName { get; set; }
        public object MemberPrimaryTeamName { get; set; }
        public int MemberPrimaryTeamNumber { get; set; }
    }
}
