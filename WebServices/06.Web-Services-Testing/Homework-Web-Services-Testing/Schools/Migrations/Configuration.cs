namespace Schools.Migrations
{
    using Schools.Context;
    using Schools.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Schools.Context.SchoolDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolDbContext context)
        {
            //Used in development process
            //var school = new School() { Name = "Telerik Academy", Location = "Sofia" };

            //var firstMark = new Mark() { Subject = "math", Value = 5.00 };
            //var secondMark = new Mark() { Subject = "math", Value = 6.00 };
            //var thirdMark = new Mark() { Subject = "math", Value = 4.00 };
            //var fourthMark = new Mark() { Subject = "c#", Value = 6.00 };
            //var fifthMark = new Mark() { Subject = "js", Value = 5.00 };
            //var sixthMark = new Mark() { Subject = "css", Value = 4.00 };

            //var firstStudent = new Student() 
            //{ 
            //    FirstName = "Nikolay",
            //    LastName = "Kostov", 
            //    Age = 21, 
            //    School = school,
            //    Grade = 12,
            //    Marks = new List<Mark>() { secondMark, fourthMark }
            //};

            //var secondStudent = new Student()
            //{
            //    FirstName = "Doncho",
            //    LastName = "Minkov",
            //    Age = 24,
            //    School = school,
            //    Grade = 11,
            //    Marks = new List<Mark>() { firstMark, fifthMark }
            //};

            //var thirdStudent = new Student()
            //{
            //    FirstName = "Georgi",
            //    LastName = "Georgiev",
            //    Age = 25,
            //    School = school,
            //    Grade = 10,
            //    Marks = new List<Mark>() { thirdMark, sixthMark }
            //};

            //school.Students = new List<Student>() { firstStudent, secondStudent, thirdStudent };

            //context.Schools.Add(school);
            //context.SaveChanges();

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
