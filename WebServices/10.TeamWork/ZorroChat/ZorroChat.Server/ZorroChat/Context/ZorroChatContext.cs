using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ZorroChat.Models;

namespace ZorroChat.Context
{
    public class ZorroChatContext
        : DbContext
    {
        public ZorroChatContext()
            : base("ZorroChatContext")
        {
        }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<User> Users { get; set; }
    }
}