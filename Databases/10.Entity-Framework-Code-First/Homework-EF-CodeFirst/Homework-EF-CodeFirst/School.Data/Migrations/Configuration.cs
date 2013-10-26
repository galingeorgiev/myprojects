namespace School.Data.Migrations
{
    using School.Data;
    using School.Model;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SchoolContext context)
        {
            context.Students.AddOrUpdate(new Student { StudentId = 1, Name = "Nikolay Kostov", Number = 12345 });
            context.Students.AddOrUpdate(new Student { StudentId = 2, Name = "Doncho Minkov", Number = 53453 });
            context.Students.AddOrUpdate(new Student { StudentId = 3, Name = "Georgi Georgiev", Number = 56756 });
            context.Students.AddOrUpdate(new Student { StudentId = 4, Name = "Petyr Petrov", Number = 34675 });
            context.Students.AddOrUpdate(new Student { StudentId = 5, Name = "Ivan Ivanov", Number = 46578 });

            context.Courses.AddOrUpdate(new Course { CourseId = 1, Name = "DB" });
            context.Courses.AddOrUpdate(new Course { CourseId = 2, Name = "C#" });
            context.Courses.AddOrUpdate(new Course { CourseId = 3, Name = "PHP" });
            context.Courses.AddOrUpdate(new Course { CourseId = 4, Name = "JS" });
            context.Courses.AddOrUpdate(new Course { CourseId = 5, Name = "C++" });

            context.Homeworks.AddOrUpdate(new Homework { Content = "DB Homework", CourseId = 1, StudentId = 1 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "C# Homework", CourseId = 2, StudentId = 2 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "PHP Homework", CourseId = 3, StudentId = 3 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "JS Homework", CourseId = 4, StudentId = 4 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "C++ Homework", CourseId = 5, StudentId = 5 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "DB Homework", CourseId = 1, StudentId = 1 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "C# Homework", CourseId = 2, StudentId = 2 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "PHP Homework", CourseId = 3, StudentId = 3 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "JS Homework", CourseId = 4, StudentId = 4 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "C++ Homework", CourseId = 5, StudentId = 5 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "DB Homework", CourseId = 1, StudentId = 1 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "C# Homework", CourseId = 2, StudentId = 2 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "PHP Homework", CourseId = 3, StudentId = 3 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "JS Homework", CourseId = 4, StudentId = 4 });
            context.Homeworks.AddOrUpdate(new Homework { Content = "C++ Homework", CourseId = 5, StudentId = 5 });
        }
    }
}