using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToolSmukfest.Models;
using ToolSmukfest.Services.MembaAPI;

namespace ToolSmukfest.Areas.Admin.Pages.Teams
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

            var response = await membaAPI.GetTeams();

            foreach (var item in response.Teams)
            {
                if (item.TeamName != null && item.IsGroup  == false) // Only sync teams with names, and no groups
                {

                    if (item.TeamName.Contains("VOV"))
                    {
                        var test = item.TeamId;
                    }
                    var team = new Team()
                    {
                        TeamId = item.TeamId,
                        Name = item.TeamName,
                        Number = item.TeamNumber,
                        IsGroup = item.IsGroup,

                        ParentId = item.TeamParentId,

                        LastSynchronization = DateTime.Now
                    };
                    _context.Teams.Add(team);
                }

            }
            await _context.SaveChangesAsync();
        }
    }
}