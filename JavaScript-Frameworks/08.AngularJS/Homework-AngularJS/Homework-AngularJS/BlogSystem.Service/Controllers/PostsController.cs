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
    public class PostsController : ApiController
    {
        public PostsController()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
        }

        // GET api/posts
        [HttpGet]
        public IEnumerable<Post> Get()
        {
            var db = new BlogContext();
            var posts = from p in db.Posts.Include(c => c.Category)
                        select p;
            return posts;
        }

        // GET api/posts/5
        [HttpGet]
        public IEnumerable<Post> Get([FromUri]int id)
        {
            var db = new BlogContext();
            var posts = from p in db.Posts.Include(c => c.Category)
                        where p.Category.Id == id
                        select p;

            return posts;
        }

        // POST api/posts
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            var db = new BlogContext();

            if (post.Category != null)
            {
                var category = (from c in db.Categories
                                where c.Name == post.Category.Name
                                select c).FirstOrDefault();

                if (category != null)
                {
                    post.Category = category;
                }
            }

            post.PostDate = DateTime.Now;

            db.Posts.Add(post);
            db.SaveChanges();
        }
    }
}
