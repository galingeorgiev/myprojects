using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaptopSystem.Web.Models;

namespace LaptopSystem.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (this.HttpContext.Cache["HomePageLaptops"] == null)
            {
                var laptops = this.Data.Laptops.All()
                .OrderByDescending(l => l.Votes.Count())
                .Take(6)
                .Select(LaptopBasicViewModel.FromLaptop);

                this.HttpContext.Cache.Add(
                    "HomePageLaptops",
                    laptops.ToList(),
                    null, 
                    DateTime.Now.AddHours(1), 
                    TimeSpan.Zero, 
                    System.Web.Caching.CacheItemPriority.Default, 
                    null);
            }

            return View(this.HttpContext.Cache["HomePageLaptops"]);
        }
    }
}