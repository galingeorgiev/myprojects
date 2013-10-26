using JustCodeJewels.Contexts;
using JustCodeJewels.DTOs;
using JustCodeJewels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Configuration;

namespace JustCodeJewels.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IRepository<Post> data;
        private string isServiceActive = ConfigurationManager.AppSettings["IsServiceActive"];

        public PostsController()
        {
            if (isServiceActive == "false")
            {
                throw new ApplicationException("Service is not active.");
            }

            this.data = new EfRepository<Post>(new CodeJewelsContext());
        }

        public PostsController(IRepository<Post> data)
        {
            if (isServiceActive == "false")
            {
                throw new ApplicationException("Service is not active.");
            }

            this.data = data;
        }

        // GET api/posts
        public IEnumerable<Post> Get()
        {
            return this.data.All();
        }

        // GET api/posts/5
        public Post Get(int id)
        {
            return this.data.Get(id);
        }

        // POST api/posts
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            this.data.Add(post);
        }

        // PUT api/posts/5?vote=true
        public void Put([FromUri]int id, [FromUri]bool vote, [FromBody]Post postDto)
        {
            var post = this.data.Get(id);

            if (vote)
            {
                post.Rating++;
            }
            else
            {
                post.Rating--;
            }

            this.data.Update(post.PostId, post);
        }

        // DELETE api/posts/5
        public void Delete(int id)
        {
            this.data.Delete(id);
        }
    }
}
