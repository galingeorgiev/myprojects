using AttributeRouting;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZorroChat.Context;
using ZorroChat.DTOs;
using ZorroChat.Models;
using ZorroChat.Repositories;

namespace ZorroChat.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly IRepository<User> data;

        public UsersController()
        {
            this.data = new EfRepository<User>(new ZorroChatContext());
        }

        public UsersController(IRepository<User> data)
        {
            this.data = data;
        }

        // GET api/users
        public IEnumerable<UserDto> Get()
        {
            var users = this.data.All();

            var usersDto = new List<UserDto>();

            foreach (var user in users)
            {
                usersDto.Add(ConvertUserToDto(user));
            }

            return usersDto;
        }

        // GET api/users/5
        public UserDto Get([FromUri]int id)
        {
            var user = this.data.Get(id);

            UserDto userDto = null;

            if (user != null)
            {
                userDto = ConvertUserToDto(user);
            }

            return userDto;
        }

        // POST api/users
        public HttpResponseMessage Post([FromBody]User user)
        {
            if (ModelState.IsValid)
            {
                this.data.Add(user);

                var userDto = ConvertUserToDto(user);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, userDto);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.UserId }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/users/5
        public HttpResponseMessage Put([FromUri]int id, [FromBody]User user)
        {
            if (ModelState.IsValid && id == user.UserId)
            {
                try
                {
                    this.data.Update(id, user);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/users/5
        public HttpResponseMessage Delete([FromUri]int id)
        {
            User user = this.data.Get(id);
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                this.data.Delete(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        }

        protected static UserDto ConvertUserToDto(User user)
        {
            var userDto = new UserDto();

            if (user.Username != null)
            {
                userDto.UserName = user.Username;
            }

            if (user.SessionKey != null)
            {
                userDto.SessionKey = user.SessionKey;
            }

            return userDto;
        }
    }
}
