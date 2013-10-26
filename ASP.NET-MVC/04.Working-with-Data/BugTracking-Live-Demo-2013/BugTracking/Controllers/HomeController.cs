using BugTracking.Data;
using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BugTracking.Controllers
{
    public class HomeController : Controller
    {
        IUowData db;

        public HomeController(IUowData db)
        {
            this.db = db;
        }

        public HomeController()
        {
            db = new UowData();
        }

        public ActionResult Index()
        {
            var model = db.Bugs.All().ToList();
            return View(model);
        }
    }
}