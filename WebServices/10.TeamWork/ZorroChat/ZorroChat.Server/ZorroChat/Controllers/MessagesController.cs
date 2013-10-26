using AttributeRouting;
using AttributeRouting.Web.Http;
using System;
using System.Collections.Generic;
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
    [RoutePrefix("api/messages")]
    public class MessagesController : ApiController
    {
        private readonly IRepository<Message> data;

        public MessagesController()
        {
            this.data = new EfRepository<Message>(new ZorroChatContext());
        }

        public MessagesController(IRepository<Message> data)
        {
            this.data = data;
        }

        // GET api/messages
        [GET("{chatId}/{sessionKey}")]
        public IEnumerable<MessageDto> Get([FromUri]int chatId, [FromUri]string sessionKey)
        {
            var messages = from m in this.data.All()
                           where m.Chat.ChatId == chatId
                           select m;

            var messagesDto = new List<MessageDto>();

            foreach (var message in messages)
            {
                messagesDto.Add(ConvertMessageToDto(message));
            }

            return messagesDto;
        }

        // GET api/messages/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/messages
        public void Post([FromBody]string value)
        {
        }

        // PUT api/messages/5
        public void Put([FromUri]int id, [FromBody]string value)
        {
        }

        // DELETE api/messages/5
        public void Delete(int id)
        {
        }

        protected static MessageDto ConvertMessageToDto(Message message)
        {
            MessageDto messageDto = null;

            if (message.MessageText != null)
            {
                messageDto.MessageText = message.MessageText;
            }

            if (message.Recepient != null)
            {
                messageDto.RecipientId = message.Recepient.UserId;
            }

            return messageDto;
        }
    }
}
