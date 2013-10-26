using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Controllers
{
    public class CustomersController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        public ActionResult ShowCustomers()
        {
            var customers = db.Customers.Take(10).ToList();
            return View(customers);
        }

        public ActionResult CustomerDetails(string id)
        {
            var customers = db.Customers.FirstOrDefault(c => c.CustomerID == id);
            return View(customers);
        }
	}
}