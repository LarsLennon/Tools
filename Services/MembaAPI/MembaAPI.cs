using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Services.MembaAPI.Models;
using ToolSmukfest.Services.MembaAPI.Responses;

namespace ToolSmukfest.Services.MembaAPI
{
    public class MembaAPI : IMembaAPI
    {
        // 96c12ee5-a7c2-4795-be85-5e3b480d6c66

        RestClient client = new RestClient("https://memba.dk");
        private const string _apiKey = "";
        private const string _apiURL = "Api/MemberApi/1/";

        public MembaAPI()
        {
        }

        private RestRequest GetRequestWithAPIKey(string apiFunction)
        {
            var request = new RestRequest(_apiURL + apiFunction, Method.GET);
            request.AddParameter("apiKey", _apiKey);
            return request;
        }

        public async Task<GetTeams> GetTeams()
        {
            var request = GetRequestWithAPIKey("GetTeams");
            request.AddParameter("apiKey", _apiKey);

            //request.AddParameter("number", "514743");
            //request.AddObject(object);

            IRestResponse<GetTeams> response = await client.ExecuteAsync<GetTeams>(request);

            return response.Data;
        }
        public async Task<GetTeamMembers> GetTeamMembers(string teamNumber)
        {
            var request = GetRequestWithAPIKey("GetTeamMembers");
            request.AddParameter("teamId", teamNumber);

            IRestResponse<GetTeamMembers> response = await client.ExecuteAsync<GetTeamMembers>(request);

            return response.Data;
        }
        public async Task<AuthenticateMember> AuthenticateMember(string username, string password)
        {
            var request = GetRequestWithAPIKey("AuthenticateMember");
            request.AddParameter("Username", username);
            request.AddParameter("Password", password);

            IRestResponse<AuthenticateMember> response = await client.ExecuteAsync<AuthenticateMember>(request);

            return response.Data;
        }


        
    }
}
