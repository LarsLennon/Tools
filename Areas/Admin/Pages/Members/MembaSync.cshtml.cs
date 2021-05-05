using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToolSmukfest.Models;
using ToolSmukfest.Services.MembaAPI;
using ToolSmukfest.Services.MembaAPI.Models;

namespace ToolSmukfest.Areas.Admin.Pages.Members
{
    public class MembaSyncModel : PageModel
    {
        private readonly ToolSmukfest.Data.ApplicationDbContext _context;

        public MembaSyncModel(ToolSmukfest.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync()
        {
            IMembaAPI membaAPI = new MembaAPI();

            var teams = await _context.Teams.Where(t => t.IsGroup == false).AsNoTracking().ToListAsync();

            foreach (var team in teams)
            {
                if (team.Name.Contains("Støttemedlem")) continue;
                if (team.Name.Contains("Superventeliste")) continue;
                if (team.Name.Contains("VOV"))
                {
                    var response = await membaAPI.GetTeamMembers(team.TeamId.ToString());
                }
                if (team.Number != "")
                {
                    var response = await membaAPI.GetTeamMembers(team.TeamId.ToString());

                    foreach (var item in response.TeamMembers)
                    {
                        var memberId = FindOrCreateMembaId(item);

                    }
                }
            }
            await _context.SaveChangesAsync();
        }

        private int FindOrCreateMembaId(TeamMember item)
        {
            Member member = _context.Members.SingleOrDefault(m => m.MemberId == item.MemberId);

            if (member == null)
            {
                member = new Member()
                {
                    MemberId = item.MemberId,
                    Name = item.MemberName,
                    MembaNumber = item.MemberNumber,
                    Email = item.Email,

                    VirtualMember = false,

                    LastSynchronization = DateTime.Now
                };
                _context.Members.Add(member);
                _context.SaveChanges();
            }
            return member.MemberId;
        }
    }
}