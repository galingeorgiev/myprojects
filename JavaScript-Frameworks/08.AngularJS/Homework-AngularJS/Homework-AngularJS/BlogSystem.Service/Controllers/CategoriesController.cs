using BlogSystem.Service.Contexts;
using BlogSystem.Service.Migrations;
using BlogSystem.Service.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlogSystem.Service.Controllers
{
    public class CategoriesController : ApiController
    {
        public CategoriesController()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
        }

        [HttpGet]
        public IEnumerable<Category> Get()
        {
            var db = new BlogContext();
            return db.Categories.ToList();
        }

        [HttpPost]
        public void Post([FromBody]Category category)
        {
            var db = new BlogContext();
            db.Categories.Add(category);
            db.SaveChanges();
        }
    }
}
