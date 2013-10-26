namespace Exam.Data.Migrations
{
    using Exam.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.ObjectModel;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<Exam.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Exam.Data.ApplicationDbContext context)
        {
            if (context.Tickets.Count() > 0)
            {
                return;
            }

            var userAdmin = new ApplicationUser()
            {
                UserName = "admin",
                Logins = new Collection<UserLogin>()
                {
                    new UserLogin()
                    {
                        LoginProvider = "Local",
                        ProviderKey = "admin",
                    }
                },
                Roles = new Collection<UserRole>()
                {
                    new UserRole()
                    {
                        Role = new Role("Admin")
                    }
                }
            };

            context.Users.Add(userAdmin);
            context.UserSecrets.Add(new UserSecret("admin",
                "ACQbq83L/rsvlWq11Zor2jVtz2KAMcHNd6x1SN2EXHs7VuZPGaE8DhhnvtyO10Nf5Q=="));//admin123

            var rand = new Random();
            for (int i = 0; i < 9; i++)
            {
                var category = new Category() { Name = "Category " + i.ToString() };
                var categoryTickets = new List<Ticket>();

                int numberOfTickets = rand.Next(2, 6);
                for (int j = 0; j < numberOfTickets; j++)
                {
                    var ticket = new Ticket()
                    {
                        Author = userAdmin,
                        Description = "Ticket description " + i.ToString(),
                        Priority = Priority.Medium,
                        ScreenshotUrl = "http://blogs.msdn.com/cfs-file.ashx/__key/communityserver-blogs-components-weblogfiles/00-00-00-36-52-metablogapi/4186.image_5F00_thumb_5F00_152BD808.png",
                        Title = "Ticket title " + i.ToString(), 
                        Category = category
                    };

                    int numberOfComments = rand.Next(3, 7);
                    var categoryComments = new List<Comment>();
                    for (int z = 0; z < numberOfComments; z++)
                    {
                        var comment = new Comment() { Author = userAdmin, Ticket = ticket, Content = "Comment content " + i.ToString() + z.ToString() };
                        categoryComments.Add(comment);
                    }

                    ticket.Comments = categoryComments;
                    categoryTickets.Add(ticket);
                }

                category.Tickets = categoryTickets;
                context.Categories.Add(category);
            }

            context.SaveChanges();
        }
    }
}
