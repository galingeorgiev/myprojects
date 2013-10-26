using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BugTracking.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BugTracking.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Bug> Bugs { get; set; }
        public IDbSet<BugsCategory> BugsCategories { get; set; }
    }
}
