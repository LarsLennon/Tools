using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToolSmukfest.Data;

namespace ToolSmukfest.Pages.Shared.Components.SectionSelector
{
    public class SectionSelectorViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext context;

        public SectionSelectorViewComponent(ApplicationDbContext context) {
            this.context = context;
        }
        public IViewComponentResult Invoke()
        {
            var sections = context.Section.ToList();
            return View("Default", sections);
        }
    }
}
