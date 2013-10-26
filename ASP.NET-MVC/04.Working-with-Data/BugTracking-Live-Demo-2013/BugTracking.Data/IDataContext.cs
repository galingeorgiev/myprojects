using BugTracking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BugTracking.Data
{
    interface IDataContext
    {
        IDbSet<Bug> Bugs { get; set; }
    }
}
