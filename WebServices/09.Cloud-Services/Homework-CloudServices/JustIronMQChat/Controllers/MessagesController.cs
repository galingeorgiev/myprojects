using IronMQ;
using IronMQ.Data;
using System;
using System.Web.Http;

namespace JustIronMQChat.Controllers
{
    public class MessagesController : ApiController
    {
        // GET api/messages
        public string Get()
        {
            Client client = new Client(
            "520fa0723c1e7f000d000002",
            "4hzKpprLTwxNNM01jw0cyNruTvk");

            var queue = client.Queue("JustChat");
            Message msg = queue.Get();
            if (msg == null)
            {
                return "empty";
            }

            return msg.Body;
        }

        // POST api/messages
        public void Post([FromBody]string value)
        {
            Client client = new Client(
            "520fa0723c1e7f000d000002",
            "4hzKpprLTwxNNM01jw0cyNruTvk");
            var queue = client.Queue("JustChat");
            queue.Push(value);
        }
    }
}
