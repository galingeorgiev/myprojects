namespace BlogSystem.Controllers
{
    using BlogSystem.Contexts;
    using BlogSystem.DTOs;
    using BlogSystem.Migrations;
    using BlogSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class PostsController : BaseApiController
    {
        private const int SessionKeyLength = 50;

        public PostsController()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>());
        }

        // GET api/posts?sessionKey=...
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

                    var allPosts = (from t in db.Posts
                                      select new PostDto()
                                      {
                                          Id = t.Id,
                                          Title = t.Title,
                                          Content = t.Content,
                                          PostedBy = t.User.Username,
                                          PostDate = t.PostDate,
                                          Tags = t.Tags.Select(tag => tag.TagText),
                                          Comments = (from c in t.Comments
                                                      select new CommentDto()
                                                      {
                                                          Id = c.Id,
                                                          Text = c.Content,
                                                          PostDate = c.CommentDate,
                                                          CommentedBy = c.User.Username
                                                      })
                                      }).ToList();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allPosts.OrderByDescending(d => d.PostDate));

                    return response;
                });

            return responseMsg;
        }

        // GET api/posts?page=1&count=1&sessionKey=...
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

                    var db = new BlogContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allPosts = (from t in db.Posts
                                    select new PostDto()
                                    {
                                        Id = t.Id,
                                        Title = t.Title,
                                        Content = t.Content,
                                        PostedBy = t.User.Username,
                                        PostDate = t.PostDate,
                                        Tags = t.Tags.Select(tag => tag.TagText),
                                        Comments = (from c in t.Comments
                                                    select new CommentDto()
                                                    {
                                                        Id = c.Id,
                                                        Text = c.Content,
                                                        PostDate = c.CommentDate,
                                                        CommentedBy = c.User.Username
                                                    })
                                    }).ToList();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allPosts.OrderByDescending(d => d.PostDate)
                                            .Skip(page * count).Take(count));

                    return response;
                });

            return responseMsg;
        }

        // POST api/posts?sessionKey=...
        [HttpPost]
        public HttpResponseMessage Post([FromUri]string sessionKey, [FromBody]PostDto postDto)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    var db = new BlogContext();

                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    if (postDto == null)
                    {
                        throw new ArgumentException("Cannot create empty post.");
                    }

                    if (postDto.Title == null)
                    {
                        throw new ArgumentException("Cannot create post without title");
                    }

                    if (postDto.Content == null)
                    {
                        throw new ArgumentException("Cannot create post without text");
                    }

                    var post = new Post() 
                    { 
                        Title = postDto.Title, 
                        Content = postDto.Content, 
                        PostDate = DateTime.Now
                    };

                    if (postDto.Tags != null)
                    {
                        foreach (var tag in postDto.Tags)
                        {
                            post.Tags.Add(new Tag() { TagText = tag });
                        }
                    }

                    var tagsFromTitle = 
                        postDto.Title.Split(new char[]{ ' ', ',', '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var tag in tagsFromTitle)
                    {
                        post.Tags.Add(new Tag() { TagText = tag });
                    }

                    db.Posts.Add(post);
                    db.SaveChanges();

                    var responsPost = new PostCreateResponseDto() { Id = post.Id, Title = post.Title };

                    var response = this.Request.CreateResponse(HttpStatusCode.Created, responsPost);

                    return response;
                });

            return responseMsg;
        }

        // GET api/posts?keyword=webapi&sessionKey=...
        [HttpGet]
        public HttpResponseMessage Get([FromUri]string sessionKey, [FromUri]string keyword)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    if (keyword == null)
                    {
                        throw new ArgumentException("Keyword is empty.");
                    }

                    var db = new BlogContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var allPosts = (from t in db.Posts
                                    where t.Title.ToLower().Contains(keyword.ToLower())
                                    select new PostDto()
                                    {
                                        Id = t.Id,
                                        Title = t.Title,
                                        Content = t.Content,
                                        PostedBy = t.User.Username,
                                        PostDate = t.PostDate,
                                        Tags = t.Tags.Select(tag => tag.TagText),
                                        Comments = (from c in t.Comments
                                                    select new CommentDto()
                                                    {
                                                        Id = c.Id,
                                                        Text = c.Content,
                                                        PostDate = c.CommentDate,
                                                        CommentedBy = c.User.Username
                                                    })
                                    }).ToList();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allPosts.OrderByDescending(d => d.PostDate));

                    return response;
                });

            return responseMsg;
        }

        // GET api/posts?tags=web,api&sessionKey=...
        [HttpGet]
        public HttpResponseMessage GetByTag([FromUri]string sessionKey, [FromUri]string tags)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (sessionKey.Length != SessionKeyLength)
                    {
                        throw new ArgumentException("Invalid session key.");
                    }

                    if (tags == null)
                    {
                        throw new ArgumentException("Tags is empty.");
                    }

                    var db = new BlogContext();

                    var user = db.Users.Where(u => u.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ApplicationException("Invalin session. Try to login.");
                    }

                    var listOfTags = tags.Split(new char[]{ ',' }, StringSplitOptions.RemoveEmptyEntries);

                    var listOfTagsLowerCase = new List<string>();
                    foreach (var tag in listOfTags)
                    {
                        listOfTagsLowerCase.Add(tag.ToLower());
                    }

                    var allPosts = (from t in db.Posts
                                    where t.Tags.Any(tag => listOfTagsLowerCase.Contains(tag.TagText.ToLower()))
                                    select new PostDto()
                                    {
                                        Id = t.Id,
                                        Title = t.Title,
                                        Content = t.Content,
                                        PostedBy = t.User.Username,
                                        PostDate = t.PostDate,
                                        Tags = t.Tags.Select(tag => tag.TagText),
                                        Comments = (from c in t.Comments
                                                    select new CommentDto()
                                                    {
                                                        Id = c.Id,
                                                        Text = c.Content,
                                                        PostDate = c.CommentDate,
                                                        CommentedBy = c.User.Username
                                                    })
                                    }).ToList();

                    var response = this.Request.CreateResponse(HttpStatusCode.OK,
                                            allPosts.OrderByDescending(d => d.PostDate));

                    return response;
                });

            return responseMsg;
        }

        // PUT api/posts/{postId}/comment&sessionKey=...
        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutComment([FromUri]string sessionKey, [FromUri]int postId, [FromBody]CommentDto commentDto)
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

                    if (commentDto == null)
                    {
                        throw new ArgumentException("Comment is empty.");
                    }

                    if (commentDto.Text == null)
                    {
                        throw new ArgumentException("Comment text is empty.");
                    }

                    var postById = db.Posts.Where(p => p.Id == postId).FirstOrDefault();

                    if (postById == null)
                    {
                        throw new ApplicationException("Invalin post ID.");
                    }

                    Comment comment = new Comment() { Content = commentDto.Text, CommentDate = DateTime.Now, User = user };

                    postById.Comments.Add(comment);
                    db.SaveChanges();

                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    return response;
                });

            return responseMsg;
        }
    }
}
