using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Twitter.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<TwitterUser>
    {
        public virtual IDbSet<Tweet> Tweets { get; set; }
    }
}
