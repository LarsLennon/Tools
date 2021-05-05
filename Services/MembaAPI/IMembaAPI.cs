using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Services.MembaAPI.Models;
using ToolSmukfest.Services.MembaAPI.Responses;

namespace ToolSmukfest.Services.MembaAPI
{
    public interface IMembaAPI
    {        
        Task<GetTeams> GetTeams(); // Henter alle hold i systemet for aktive sæson
               
        Task<GetTeamMembers> GetTeamMembers(string teamNumber); // Henter holdlisten ud for et specifikt hold

        Task<AuthenticateMember> AuthenticateMember(string username, string password); // Log medlem ind med memba oplysninger
    }
}
