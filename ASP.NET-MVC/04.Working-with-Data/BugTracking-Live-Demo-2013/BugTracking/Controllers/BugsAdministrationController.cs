using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BugTracking.Models;
using BugTracking.Data;

namespace BugTracking.Controllers
{
    public class BugsAdministrationController : Controller
    {
        private DataContext db = new DataContext();

        // GET: /BugsAdministration/
        public ActionResult Index()
        {
            return View(db.Bugs.ToList());
        }

        // GET: /BugsAdministration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // GET: /BugsAdministration/Create
        public ActionResult Create()
        {
            ViewBag.Categories = db.BugsCategories.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });

            return View();
        }

        // POST: /BugsAdministration/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bug bug)
        {
            if (bug.Description == bug.Title)
            {
                ModelState.AddModelError("Description", "Description and Title should have different values!");
                ModelState.AddModelError("Description", "Description and Title should have different values!123");
            }

            if (ModelState.IsValid)
            {
                db.Bugs.Add(bug);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.BugsCategories.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(bug);
        }

        // GET: /BugsAdministration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.BugsCategories.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(bug);
        }

        // POST: /BugsAdministration/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bug bug)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bug).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.BugsCategories.ToList().Select(x => new SelectListItem { Text = x.Name, Value = x.Id.ToString() });
            return View(bug);
        }

        // GET: /BugsAdministration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bug bug = db.Bugs.Find(id);
            if (bug == null)
            {
                return HttpNotFound();
            }
            return View(bug);
        }

        // POST: /BugsAdministration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bug bug = db.Bugs.Find(id);
            db.Bugs.Remove(bug);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
