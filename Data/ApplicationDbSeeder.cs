using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolSmukfest.Models;

namespace ToolSmukfest.Data
{
    public static class ApplicationDbSeeder
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Festival.Any())
            {
                return;   // DB has been seeded
            }

            var festivals = new Festival[]
            {
                new Festival{Title="Smukfest 2018"},
                new Festival{Title="Smukfest 2019"},
                new Festival{Title="Smukfest 2020"}
            };
            context.Festival.AddRange(festivals);
            Festival currentsmukfest = new Festival { Title = "Smukfest 2021" };
            context.Festival.Add(currentsmukfest);

            context.SaveChanges();

            var sections = new Section[]
            {
                new Section{Title="Entreprenør materiel",IsActive=true,FestivalId=currentsmukfest.FestivalId},
                new Section{Title="GSV og Gear up hotel",IsActive=true,FestivalId=currentsmukfest.FestivalId},
                new Section{Title="Køretøjer",IsActive=true,FestivalId=currentsmukfest.FestivalId},
                new Section{Title="GODIK Grej",IsActive=true,FestivalId=currentsmukfest.FestivalId},
                new Section{Title="GSV",IsActive=true,FestivalId=currentsmukfest.FestivalId},
                new Section{Title="GUG",IsActive=true,FestivalId=currentsmukfest.FestivalId},
            };

            context.Section.AddRange(sections);
            context.SaveChanges();
        }
    }
}
