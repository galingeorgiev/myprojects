using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using CarStore.Data;

namespace CarStore.Service.Models
{
    public class CarStoreSystemContextFactory : IDbContextFactory<DbContext>
    {
        public DbContext Create()
        {
            return new CarStoreContext();
        }
    }
}