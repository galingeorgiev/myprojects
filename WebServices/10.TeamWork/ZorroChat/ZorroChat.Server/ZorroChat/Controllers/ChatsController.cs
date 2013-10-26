using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZorroChat.Context;
using ZorroChat.Models;
using ZorroChat.Repositories;

namespace ZorroChat.Controllers
{
    public class ChatsController : ApiController
    {
        private readonly IRepository<Chat> data;

        public ChatsController()
        {
            this.data = new EfRepository<Chat>(new ZorroChatContext());
        }

        public ChatsController(IRepository<Chat> data)
        {
            this.data = data;
        }

        // GET api/chats
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/chats/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/chats
        public void Post([FromBody]string value)
        {
        }

        // PUT api/chats/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/chats/5
        public void Delete(int id)
        {
        }
    }
}
