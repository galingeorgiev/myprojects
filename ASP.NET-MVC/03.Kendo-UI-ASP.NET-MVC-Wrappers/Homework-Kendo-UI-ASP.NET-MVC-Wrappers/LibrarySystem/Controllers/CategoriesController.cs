using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibrarySystem.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using LibrarySystem.ViewModels;

namespace LibrarySystem.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Categories/
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetCategories([DataSourceRequest] DataSourceRequest request)
        {
            var categories = db.Categories.Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name
            });

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCategoriesDetails([DataSourceRequest] DataSourceRequest request)
        {
            var categories = db.Categories.Select(c => new CategoryWithBooksViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Books = c.Books.Select(b => new BooksViewModel() 
                {
                    Id = b.Id,
                    Author = b.Author, 
                    Title = b.Title, 
                })
            });

            return Json(categories.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult GetCategoriesFor()
        {
            var categories = db.Categories.Select(c => new CategoryViewModel() 
                {
                    Id = c.Id, 
                    Name = c.Name
                });

            return this.Json(categories, JsonRequestBehavior.AllowGet);
        }

        // GET: /Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (ModelState.IsValid)
            {
                var categoryToCreate = new Category() 
                {
                    Id = category.Id,
                    Name = category.Name
                };

                db.Categories.Add(categoryToCreate);
                db.SaveChanges();
            }

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var categoryToUpdate = db.Categories.FirstOrDefault(c => c.Id == category.Id);
                categoryToUpdate.Name = category.Name;
                db.SaveChanges();
            }

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: /Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed([DataSourceRequest] DataSourceRequest request, CategoryViewModel category)
        {
            if (category != null && ModelState.IsValid)
            {
                var categoryToDelete = db.Categories.FirstOrDefault(c => c.Id == category.Id);
                db.Categories.Remove(categoryToDelete);
                db.SaveChanges();
            }
            
            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
