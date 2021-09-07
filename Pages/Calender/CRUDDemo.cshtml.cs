using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ToolSmukfest.Models;
using ToolSmukfest.Models.DTO;
using ToolSmukfest.Data;
using RestSharp;
using ToolSmukfest.Services.MembaAPI;

namespace ToolSmukfest
{
    public class CRUDDemoModel : PageModel
    {
        private ApplicationDbContext _context;
        [BindProperty]
        public string Resources { get; set; }
        [BindProperty]
        public string Events { get; set; }
        [BindProperty]
        public int DaysInMonth { get; set; } = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        public CRUDDemoModel(ApplicationDbContext context)
        {
            _context = context;
            Initializedb();
        }
        private void Initializedb()
        {
            if (!_context.Projects.Any())
            {
                _context.Projects.Add(new Project()
                {
                    title = "KBL31",
                    iscomplete = false

                });
                _context.SaveChanges();
                _context.Events.Add(new Event()
                {
                    ProjectId = _context.Projects.First().id,
                    title = "Skilteholdet",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(3)
                });
                _context.SaveChanges();
                _context.Events.Add(new Event()
                {
                    ProjectId = _context.Projects.First().id,
                    title = "Truck",
                    StartDate = DateTime.Now.AddDays(3),
                    EndDate = DateTime.Now.AddDays(10)
                });
                _context.SaveChanges();
            }
        }
        public void OnGet()
        {
            /*
            IMembaAPI emailSender = new MembaAPI();

            var teams = emailSender.GetTeams();

            foreach (var item in teams.Result.Teams)
            {

            }*/
            // 96c12ee5-a7c2-4795-be85-5e3b480d6c66
            /*
        var client = new RestClient("https://memba.dk");

        var request = new RestRequest("Api/MemberApi/1/GetTeams", Method.GET);
        //request.AddParameter("number", "514743");
        request.AddParameter("apiKey", "96c12ee5-a7c2-4795-be85-5e3b480d6c66");
        //request.AddObject(object);
        IRestResponse<GetTeams> response = client.Execute<GetTeams>(request);

        foreach (var item in response.Data.Teams)
        {
            var memberRequest = new RestRequest("Api/MemberApi/1/GetTeamMembers", Method.GET);
            memberRequest.AddParameter("teamId", item.TeamId);
            memberRequest.AddParameter("apiKey", "96c12ee5-a7c2-4795-be85-5e3b480d6c66");

            IRestResponse<GetTeamMembers> memberResponse = client.Execute<GetTeamMembers>(memberRequest);

            foreach (var teamMember in memberResponse.Data.TeamMembers)
            {

                var member = new Member()
                {
                    Name = teamMember.MemberName,
                    Email = teamMember.Email
                };

                if (teamMember.MemberNumber != "")
                {
                    try
                    {
                        member.Number = Convert.ToInt32(teamMember.MemberNumber);
                    }
                    catch (Exception)
                    {

                    }
                }
                _context.Member.Add(member);
            }
           // _context.Team.Add(team);
        }

        _context.SaveChanges();
        */

            //var content = response.Content;

            var listOfProjects = _context.MembaOrderLines.Where( m => m.ItemTypeId == 1).ToList();
            var listOfResource = new List<Resources>();
            var listOfEventResources = new List<EventResources>();
            foreach (var item in listOfProjects)
            {
                var obj = new Resources();
                obj.id = item.MembaOrderLineId;
                obj.title = item.Product;
                if (true)
                {
                    obj.status = "Completed";
                    obj.eventColor = "green";
                }
                else
                {
                    obj.status = "On Going";
                    obj.eventColor = "red";
                }
                listOfResource.Add(obj);



                var evt = new EventResources();
                evt.title = item.Product + " " + item.MembaOrderLineId.ToString();
                evt.resourceId = obj.id;
                evt.id = item.MembaOrderLineId;
                evt.start = item.From.ToString("yyyy-MM-ddTHH\\:mm\\:ss");
                evt.end = item.To.ToString("yyyy-MM-ddTHH\\:mm\\:ss");
                listOfEventResources.Add(evt);
            }

            Resources = JsonConvert.SerializeObject(listOfResource);
            Events = JsonConvert.SerializeObject(listOfEventResources);
        }
    }
}