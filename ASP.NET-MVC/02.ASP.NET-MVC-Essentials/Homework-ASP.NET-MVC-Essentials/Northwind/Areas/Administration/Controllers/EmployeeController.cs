using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Northwind.Areas.Administration.Controllers
{
    public class EmployeeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        public ActionResult EmployeeDetails()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
	}
}