using MccordMission7.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MccordMission7.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBooksRepository rep { get; set; }
        
        public CategoriesViewComponent (IBooksRepository shorty)
        {
            rep = shorty;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.ChoiceCategory = RouteData?.Values["bookCategory"];
            var cats = rep.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cats);
        }
    }
}
