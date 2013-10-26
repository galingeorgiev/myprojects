namespace JustForum.Controllers
{
    using AttributeRouting;
    using AttributeRouting.Web.Http;
    using JustForum.Contexts;
    using JustForum.DTOs;
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    [RoutePrefix("api/threads")]
    public class ThreadsController : BaseApiController
    {
        private const int SessionKeyLength = 50;

        // GET api/threads/sessionKey
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

                    var db = new ForumContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allThreads = (from t in db.Threads
                                     select new ThreadDto()
                                     {
                                         Id = t.Id,
                                         Title = t.Title,
                                         Content = t.Content,
                                         CreatedBy = t.User.Username,
                                         DateCreated = t.DateCreated,
                                         Categories = t.Categories.Select(c => c.Name),
                                         Posts = (from p in t.Posts
                                                 select new PostDto() 
                                                 { 
                                                     Id = p.Id,
                                                     Content = p.Content, 
                                                     PostDate = p.PostDate, 
                                                     PostedBy = p.User.Username,
                                                     Rating = (int)p.Votes.Select(v => v.Value).Average()
                                                 })
                                     });

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allThreads.OrderByDescending(d => d.DateCreated));

                    return response;
                });

            return responseMsg;
        }

        // api/threads/sessionKey?category="requests"
        [HttpGet]
        public HttpResponseMessage Get([FromUri]string sessionKey, [FromUri]string category)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    var db = new ForumContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allThreads = (from t in db.Threads
                                      where t.Categories.Any(c => c.Name == category)
                                      select new ThreadDto()
                                      {
                                          Id = t.Id,
                                          Title = t.Title,
                                          Content = t.Content,
                                          CreatedBy = t.User.Username,
                                          DateCreated = t.DateCreated,
                                          Categories = t.Categories.Select(c => c.Name),
                                          Posts = (from p in t.Posts
                                                   select new PostDto()
                                                   {
                                                       Id = p.Id,
                                                       Content = p.Content,
                                                       PostDate = p.PostDate,
                                                       PostedBy = p.User.Username
                                                   })
                                      });

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allThreads.OrderByDescending(d => d.DateCreated));

                    return response;
                });

            return responseMsg;
        }

        // api/threads/sessionKey?page=1&count=2
        [HttpGet]
        public HttpResponseMessage Get([FromUri]string sessionKey, [FromUri]int page, [FromUri]int count)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    var db = new ForumContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allThreads = (from t in db.Threads
                                      select new ThreadDto()
                                      {
                                          Id = t.Id,
                                          Title = t.Title,
                                          Content = t.Content,
                                          CreatedBy = t.User.Username,
                                          DateCreated = t.DateCreated,
                                          Categories = t.Categories.Select(c => c.Name),
                                          Posts = (from p in t.Posts
                                                   select new PostDto()
                                                   {
                                                       Id = p.Id,
                                                       Content = p.Content,
                                                       PostDate = p.PostDate,
                                                       PostedBy = p.User.Username
                                                   })
                                      });

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allThreads.OrderByDescending(d => d.DateCreated).Skip(page * count).Take(count));

                    return response;
                });

            return responseMsg;
        }

        // GET api/threads/sessionKey/1/posts
        [HttpGet]
        [GET("{sessionKey}/{id}/posts")]
        public HttpResponseMessage Get([FromUri]string sessionKey, [FromUri]int id)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    var db = new ForumContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allThreads = (from t in db.Threads
                                      where t.Id == id
                                      select new ThreadDto()
                                      {
                                          Id = t.Id,
                                          Title = t.Title,
                                          Content = t.Content,
                                          CreatedBy = t.User.Username,
                                          DateCreated = t.DateCreated,
                                          Categories = t.Categories.Select(c => c.Name),
                                          Posts = (from p in t.Posts
                                                   select new PostDto()
                                                   {
                                                       Id = p.Id,
                                                       Content = p.Content,
                                                       PostDate = p.PostDate,
                                                       PostedBy = p.User.Username
                                                   })
                                      });

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allThreads.OrderByDescending(d => d.DateCreated));

                    return response;
                });

            return responseMsg;
        }
    }
}
