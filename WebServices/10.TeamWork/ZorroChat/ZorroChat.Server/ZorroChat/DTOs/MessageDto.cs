using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZorroChat.DTOs
{
    public class MessageDto
    {
        public string MessageText { get; set; }

        public int RecipientId { get; set; }
    }
}