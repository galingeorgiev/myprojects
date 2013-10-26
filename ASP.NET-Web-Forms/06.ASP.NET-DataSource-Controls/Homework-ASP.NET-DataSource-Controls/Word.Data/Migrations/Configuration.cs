namespace Word.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Word.Data;
    using Word.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<Word.Data.WordContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(WordContext context)
        {
            context.Continents.AddOrUpdate(
                new Continent() { Name = "Asia" },
                new Continent() { Name = "Africa" },
                new Continent() { Name = "North America" },
                new Continent() { Name = "South America" },
                new Continent() { Name = "Antarctica" },
                new Continent() { Name = "Europe" },
                new Continent() { Name = "Australia" });

            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
