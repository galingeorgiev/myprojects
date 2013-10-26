namespace MyLaptopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MyLaptopSystem.Models;
    using System.Collections.Generic;

    public sealed class Configuration : DbMigrationsConfiguration<MyLaptopSystem.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MyLaptopSystem.Data.ApplicationDbContext context)
        {
            if (context.Laptops.Count() > 0)
            {
                return;
            }

            var rand = new Random();
            var user = new ApplicationUser() { UserName = "gosho" };

            for (int i = 0; i < 8; i++)
            {
                var currentManufacturer = new Manufacturer() { Name = "Lenovo " + i.ToString() };

                for (int j = 0; j < 12; j++)
                {
                    var currentLaptop = new Laptop()
                    {
                        AdditionalParts = "Bluetooth",
                        Description = "Description for" + currentManufacturer.Name,
                        HardDisk = rand.Next(100, 1000),
                        ImageUrl = "http://laptop.bg/system/images/14757/normal/ThinkPad_T530.gif?1345207100",
                        Model = "ThinkPad T530 - " + j.ToString(),
                        Monitor = rand.NextDouble() * 100,
                        Price = rand.Next(500, 6000),
                        Ram = rand.Next(4, 32),
                        Weight = rand.Next(1, 5),
                        Manufacturer = currentManufacturer
                    };

                    var comments = new List<Comment>();
                    for (int z = 0; z < 7; z++)
                    {
                        var currentComment = new Comment()
                        {
                            Laptop = currentLaptop,
                            Author = user,
                            Content = "Best laptop ever " + z.ToString()
                        };

                        comments.Add(currentComment);
                    }

                    currentLaptop.Comments = comments;

                    var votes = new List<Vote>();
                    var votesCount = rand.Next(5, 15);
                    for (int z = 0; z < votesCount; z++)
                    {
                        var vote = new Vote()
                        {
                            Laptop = currentLaptop,
                            VotedBy = user
                        };

                        votes.Add(vote);
                    }

                    currentLaptop.Votes = votes;
                    context.Laptops.Add(currentLaptop);
                }
            }

            context.SaveChanges();
        }
    }
}
