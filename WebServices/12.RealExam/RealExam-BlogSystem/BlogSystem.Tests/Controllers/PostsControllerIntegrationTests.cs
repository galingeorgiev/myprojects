namespace BlogSystem.Tests.Controllers
{
    using BlogSystem.Controllers;
    using BlogSystem.DTOs;
    using BlogSystem.Tests.InMemoryHttpServers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Net;
    using System.Transactions;

    [TestClass]
    public class PostsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var typeUser = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                //api/posts/{postId}/comment
                new Route(
                    "CustomPostsApi",
                    "api/posts/{postId}/comment",
                    new 
                    {
                        controller = "posts",
                        action = "comment"
                    }),
                new Route(

                    "DefaultPostsApi",
                    "api/posts",
                    new 
                    {
                        controller = "posts"
                    }),
                    new Route(
                    "DefaultUsersApi",
                    "api/users/{action}",
                    new 
                    {
                        controller = "users"
                    })
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Post_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var post = new PostDto()
            {
                Title = "Test Title",
                Content = "Test post text",
                Tags = new List<string>() { "tag1", "Tag2" }
            };


            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, post);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostWithoutTags_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var post = new PostDto()
            {
                Title = "Test Title",
                Content = "Test post text"
            };


            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, post);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostsByTags_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var post = new PostDto()
            {
                Title = "Test Title",
                Content = "Test post text",
                Tags = new List<string>() { "tag1", "Tag2" } // This chesk is searching is case insensitive
            };


            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, post);

            var responseByTags = httpServer.Get("api/posts?tags=tag1,tag2&sessionKey=" + userModel.SessionKey);

            // Check is post with tags added to database(in current transaction).
            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);

            Assert.AreEqual(HttpStatusCode.OK, responseByTags.StatusCode);
            Assert.IsNotNull(responseByTags.Content);
        }

        [TestMethod]
        public void PutComment_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var post = new PostDto()
            {
                Title = "Test Title",
                Content = "Test post text",
                Tags = new List<string>() { "tag1", "Tag2" }
            };

            var commentDto = new CommentDto() { Text = "Test comment" };


            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            var response = httpServer.Post("api/posts?sessionKey=" + userModel.SessionKey, post);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postDto = JsonConvert.DeserializeObject<PostDto>(contentString);

            var responsePutComment = httpServer.Put(
                "api/posts/" + postDto.Id + "/comment?sessionKey=" + userModel.SessionKey, 
                commentDto);

            Assert.AreEqual(HttpStatusCode.OK, responsePutComment.StatusCode);
            Assert.IsNull(responsePutComment.Content);
        }

        [TestMethod]
        public void GetAllPostsByCountAndPage_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            var response = httpServer.Get("api/posts?sessionKey=" + userModel.SessionKey + "&page=0&count=2");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        private UserLogedDto RegisterTestUser(InMemoryHttpServer httpServer, UserDto testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<UserLogedDto>(contentString);
            return userModel;
        }
    }
}
