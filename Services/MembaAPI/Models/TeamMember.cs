using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolSmukfest.Services.MembaAPI.Models
{
    public class TeamMember
    {
        public int TeamId { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberNumber { get; set; }
        public string MemberProfession { get; set; } 
        public string MemberSecondaryProfession { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string MobilePhoneVenue { get; set; }
        public string Phone { get; set; }
        public string TeamNumber { get; set; }
        public string TeamName { get; set; }
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleAlias { get; set; }
        public int TitleSerial { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleAlias { get; set; }
        public int RoleSerial { get; set; }
        public bool IsPrimary { get; set; }
        public int TeamMemberStatusId { get; set; }
    }
}
