﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStore.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BookStoreDBEntities : DbContext
    {
        public BookStoreDBEntities()
            : base("name=BookStoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Rewiew> Rewiews { get; set; }
    }
}
