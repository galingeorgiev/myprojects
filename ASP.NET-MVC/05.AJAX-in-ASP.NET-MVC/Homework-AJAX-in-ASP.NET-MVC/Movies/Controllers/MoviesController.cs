using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movies.Models;

namespace Movies.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();

        // GET: /Movies/
        public ActionResult Index()
        {
            return View(db.Movies.ToList());
        }

        // GET: /Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies
                .Include(m => m.LeadingMaleRole)
                .Include(m => m.LeadingFemaleRole)
                .FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: /Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Movies/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: /Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies
                .AsNoTracking()
                .Include(m => m.LeadingMaleRole)
                .Include(m => m.LeadingFemaleRole)
                .FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                var fromDb = db.Movies
                    .Include(m => m.LeadingMaleRole)
                    .Include(m => m.LeadingFemaleRole)
                    .FirstOrDefault(m => m.Id == movie.Id);

                fromDb.Title = movie.Title;
                fromDb.Year = movie.Year;
                fromDb.StudioName = movie.StudioName;
                fromDb.StudioAddress = movie.StudioAddress;
                fromDb.LeadingMaleRole.Name = movie.LeadingMaleRole.Name;
                fromDb.LeadingMaleRole.Age = movie.LeadingMaleRole.Age;
                fromDb.LeadingFemaleRole.Name = movie.LeadingFemaleRole.Name;
                fromDb.LeadingFemaleRole.Age = movie.LeadingFemaleRole.Age;

                //db.Movies.Attach(movie);
                //db.Actors.Attach(movie.LeadingMaleRole);
                //db.Actors.Attach(movie.LeadingFemaleRole);
                //db.Entry(movie).State = EntityState.Modified;
                //db.Entry(movie.LeadingFemaleRole).State = EntityState.Modified;
                //db.Entry(movie.LeadingFemaleRole).State = EntityState.Modified;
                //db.Entry(fromDb).CurrentValues.SetValues(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
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
