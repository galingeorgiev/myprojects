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
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Books/
        public ActionResult Index()
        {
            ViewData["defaultCategory"] = db.Categories.Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .First();

            return View();//db.Books.ToList()
        }

        [Authorize]
        public ActionResult GetBooks([DataSourceRequest] DataSourceRequest request)
        {
            var books = db.Books.Select(b => new BooksViewModel()
            {
                Id = b.Id,
                Author = b.Author,
                Description = b.Description,
                ISBN = b.ISBN,
                Title = b.Title,
                WebSite = b.WebSite,
                Category = new CategoryViewModel()
                    {
                        Id = b.Category.Id,
                        Name = b.Category.Name
                    }
            });

            return Json(books.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }

        // GET: /Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BooksViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var category = db.Categories.FirstOrDefault(c => c.Id == book.Category.Id);
                var bookToCreate = new Book();
                bookToCreate.Id = book.Id;
                bookToCreate.Author = book.Author;
                bookToCreate.Category = category;
                bookToCreate.Description = book.Description;
                bookToCreate.ISBN = book.ISBN;
                bookToCreate.Title = book.Title;
                bookToCreate.WebSite = book.WebSite;

                db.Books.Add(bookToCreate);
                db.SaveChanges();
            }

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        [HttpPost]
        public ActionResult Edit([DataSourceRequest] DataSourceRequest request, BooksViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var bookToUpdate = db.Books.FirstOrDefault(b => b.Id == book.Id);
                bookToUpdate.Author = book.Author;
                bookToUpdate.Category.Id = book.Category.Id;
                bookToUpdate.Category.Name = book.Category.Name;
                bookToUpdate.Description = book.Description;
                bookToUpdate.ISBN = book.ISBN;
                bookToUpdate.Title = book.Title;
                bookToUpdate.WebSite = book.WebSite;
                db.SaveChanges();
            }

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        // POST: /Books/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, BooksViewModel book)
        {
            if (book != null && ModelState.IsValid)
            {
                var bookToDelete = db.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == book.Id);
                db.Books.Remove(bookToDelete);
                db.SaveChanges();
            }

            return Json(ModelState.IsValid ? true : ModelState.ToDataSourceResult());
        }

        [HttpPost]
        public ActionResult FindBooks(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                var booksAll = db.Books
                .Select(b => new BooksViewModel()
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    Category = new CategoryViewModel() { Name = b.Category.Name }
                });

                return View(booksAll);
            }

            var books = db.Books
                .Where(b => b.Author.ToLower().Contains(query.ToLower()) || b.Title.ToLower().Contains(query.ToLower()))
                .Select(b => new BooksViewModel()
                {
                    Id = b.Id,
                    Author = b.Author,
                    Title = b.Title,
                    Category = new CategoryViewModel() { Name = b.Category.Name }
                });

            return View(books);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
