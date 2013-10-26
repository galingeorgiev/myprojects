using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class CategoriesController : Controller
    {

        NorthwindEntities db = new NorthwindEntities();

        public ActionResult ShowAll()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }
	}
}