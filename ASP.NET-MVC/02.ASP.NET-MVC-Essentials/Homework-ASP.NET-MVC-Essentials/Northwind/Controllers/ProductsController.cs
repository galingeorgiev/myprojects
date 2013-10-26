using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class ProductsController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult ProductsByCategory(int id)
        {
            var products = db.Products.Include("Supplier").Where(p => p.CategoryID == id).ToList();
            return View(products);
        }
	}
}