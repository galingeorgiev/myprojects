namespace BlogSystem.Controllers
{
    using BlogSystem.Contexts;
    using BlogSystem.DTOs;
    using BlogSystem.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class TagsController : BaseApiController
    {
        private const int SessionKeyLength = 50;

        public TagsController()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
        }

        // GET api/tags?sessionKey=...
        [HttpGet]
        public HttpResponseMessage Get([FromUri]string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    var db = new BlogContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allPosts = (from t in db.Tags
                                    select new TagDto() 
                                    {
                                        Id = t.Id, 
                                        Name = t.TagText,
                                        Posts = db.Posts.Where(
                                        p => p.Tags.Any(tag => tag.TagText.ToLower() == t.TagText.ToLower()))
                                        .Count()
                                    }).ToList();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allPosts.OrderByDescending(d => d.Name));

                    return response;
                });

            return responseMsg;
        }
    }
}
