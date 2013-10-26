namespace BlogSystem.Service.Migrations
{
    using BlogSystem.Service.Contexts;
    using BlogSystem.Service.Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogSystem.Service.Contexts.BlogContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogContext context)
        {
            var cSharpCategory = new Category() { Name = "C#" };
            var cssCategory = new Category() { Name = "CSS" };
            var jsCategory = new Category() { Name = "JS" };
            context.Posts.AddOrUpdate(
                new Post() { PostDate = DateTime.Now, Title = "About C#", Content = "Some content 1", Category = cSharpCategory },
                new Post() { PostDate = DateTime.Now, Title = "About JS", Content = "Some content 2", Category = jsCategory },
                new Post() { PostDate = DateTime.Now, Title = "About CSS", Content = "Some content 3", Category = cssCategory },
                new Post() { PostDate = DateTime.Now, Title = "Intro C#", Content = "Some content 4", Category = cSharpCategory },
                new Post() { PostDate = DateTime.Now, Title = "Intro JS", Content = "Some content 5", Category = jsCategory },
                new Post() { PostDate = DateTime.Now, Title = "Intro CSS", Content = "Some content 6", Category = cssCategory });
        }
    }
}
