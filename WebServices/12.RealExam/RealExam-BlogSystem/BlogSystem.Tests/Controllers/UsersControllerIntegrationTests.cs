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
    public class UsersControllerIntegrationTests
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
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void RegisterUser_WhenAuthCodeIsInvalid_ShouldReturn400()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 39) // Invalin AuthCode
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_WhenUsernameIsInvalid_ShouldReturn400()
        {
            var testUser = new UserDto()
            {
                Username = "",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_WhenDisplayNameIsInvalid_ShouldReturn400()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "",
                AuthCode = new string('b', 40)
            };

            var response = httpServer.Post("api/users/register", testUser);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_WhenDisplayNameExistInDb()
        {
            var validTestUser = new UserDto()
            {
                Username = "VALIDUSER1",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var testUserExistInDb = new UserDto()
            {
                Username = "VALIDUSER2",
                DisplayName = "VALIDDISPLAYNAME", // Duplicated DisplayName
                AuthCode = new string('b', 40)
            };

            var responseOk = httpServer.Post("api/users/register", validTestUser);
            var responseBadRequest = httpServer.Post("api/users/register", testUserExistInDb);

            Assert.AreEqual(HttpStatusCode.Created, responseOk.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseBadRequest.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_WhenUserNameExistInDb()
        {
            var validTestUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME1",
                AuthCode = new string('b', 40)
            };

            var testUserExistInDb = new UserDto()
            {
                Username = "VALIDUSER", // Duplicated Username
                DisplayName = "VALIDDISPLAYNAME2", 
                AuthCode = new string('b', 40)
            };

            var responseOk = httpServer.Post("api/users/register", validTestUser);
            var responseBadRequest = httpServer.Post("api/users/register", testUserExistInDb);

            Assert.AreEqual(HttpStatusCode.Created, responseOk.StatusCode);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseBadRequest.StatusCode);
        }

        [TestMethod]
        public void RegisterUser_WhenUserIsNull()
        {
            var testUserExistInDb = new UserDto();

            var responseBadRequest = httpServer.Post("api/users/register", testUserExistInDb);

            Assert.AreEqual(HttpStatusCode.BadRequest, responseBadRequest.StatusCode);
        }

        [TestMethod]
        public void LogoutUser_WhenUserModelValid()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(httpServer, testUser);

            var responseLogout = httpServer.Put("api/users/logout?sessionKey=" + userModel.SessionKey, testUser);
            Assert.AreEqual(HttpStatusCode.OK, responseLogout.StatusCode);
        }

        [TestMethod]
        public void LogoutUser_WhenSessionKeyIsInvalid()
        {
            var testUser = new UserDto()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDDISPLAYNAME",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(httpServer, testUser);

            string invalidSessionKey = new string('b', 50);
            var responseLogout = httpServer.Put("api/users/logout?sessionKey=" + invalidSessionKey, testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, responseLogout.StatusCode);
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