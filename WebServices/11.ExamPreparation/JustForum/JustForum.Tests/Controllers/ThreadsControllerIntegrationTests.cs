using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JustForum.Tests.InMemoryHttpServers;
using System.Transactions;
using JustForum.Controllers;
using System.Collections.Generic;
using JustForum.DTOs;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;

namespace JustForum.Tests.Controllers
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {

            var typeUser = typeof(UsersController);
            var typeThreads = typeof(ThreadsController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "DefaultUsersApi",
                    "api/threads/{sessionKey}",
                    new
                    {
                        controller = "threads",
                        sessionKey = RouteParameter.Optional
                    }),
                new Route(
                     "UsersApi",
                     "api/{controller}/{action}/{sessionKey}",
                     new
                        {
                            sessionKey = RouteParameter.Optional
                        }),
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            //var httpServer = new InMemoryHttpServer("http://localhost/");
            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void GetAll_WhenDataInDatabase_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            var response = httpServer.Get("api/threads/" + userModel.SessionKey);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetAllPosts_WhenDataInDatabase_ShouldReturnData()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);
            //api/threads/sessionKey/1/posts
            var response = httpServer.Get("api/threads/" + userModel.SessionKey + "?page=0&count=2");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void GetAllPosts_WhenDataInDatabase_ShouldReturnData_CustomAttributes()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var routes = new List<Route>
            {
                new Route(
                    "CustomThreadsApi",
                    "api/threads/{sessionKey}/{id}/posts",
                    new
                    {
                        controller = "threads",
                        sessionKey = RouteParameter.Optional,
                        id = RouteParameter.Optional
                    }),
                    new Route(
                    "CustomThreadsApiGetAll",
                    "api/threads/{sessionKey}",
                    new
                    {
                        controller = "threads",
                        sessionKey = RouteParameter.Optional
                    }),
                new Route(
                     "UsersApi",
                     "api/{controller}/{action}/{sessionKey}",
                     new
                        {
                            sessionKey = RouteParameter.Optional
                        })
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);

            UserLogedDto userModel = RegisterTestUser(httpServer, testUser);

            //api/threads/sessionKey
            string urlGetAllThreads = "api/threads/" + userModel.SessionKey;
            var responseAllThreads = httpServer.Get(urlGetAllThreads).Content.ReadAsStringAsync().Result;
            var threads = JsonConvert.DeserializeObject<IEnumerable<ThreadDto>>(responseAllThreads);
            ThreadDto firstThread = new ThreadDto();
            if (threads != null)
            {
                foreach (var thr in threads)
                {
                    firstThread = thr;
                    break;
                }
            }

            //api/threads/sessionKey/1/posts
            string url = "api/threads/" + userModel.SessionKey + "/" + firstThread.Id + "/posts";
            var response = httpServer.Get(url);

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