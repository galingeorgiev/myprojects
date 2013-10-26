/* Write unit tests for:
 * The StudentsRepository
 */

namespace Schools.Tests.Repositories
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Data.Entity;
    using Schools.Repositories;
    using Schools.Models;
    using System.Transactions;
    using Schools.Context;
    using System.Collections.Generic;

    [TestClass]
    public class EfStudentsRepositoryTest
    {
        public DbContext Context { get; set; }

        public IRepository<Student> StudentsRepository { get; set; }

        private static TransactionScope tranScope;

        public EfStudentsRepositoryTest()
        {
            this.Context = new SchoolDbContext();
            this.StudentsRepository = new EfRepository<Student>(this.Context);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void Add_ValidStudent_CheckIsIdCorrect()
        {
            string firstName = "Nikolay";
            string lastName = "Kostov";
            var student = MakeSimpleStudent(firstName, lastName);

            this.Context.Set<Student>().Add(student);
            this.Context.SaveChanges();

            Assert.IsTrue(student.StudentId > 0);
        }

        [TestMethod]
        public void Add_ValidStudent_CheckIsMarksAdded()
        {
            string firstName = "Nikolay";
            string lastName = "Kostov";
            var student = MakeSimpleStudent(firstName, lastName);

            this.Context.Set<Student>().Add(student);
            this.Context.SaveChanges();

            Assert.IsTrue(student.Marks.Count == 4);
        }

        [TestMethod]
        public void Add_ValidStudent_CheckIsStudentNamesCorrect()
        {
            string firstName = "Nikolay";
            string lastName = "Kostov";
            var student = MakeSimpleStudent(firstName, lastName);

            this.Context.Set<Student>().Add(student);
            this.Context.SaveChanges();

            Assert.IsTrue(student.FirstName == firstName);
            Assert.IsTrue(student.LastName == lastName);
        }

        private static Student MakeSimpleStudent(string firstName, string lastName)
        {
            var school = new School() { Name = "Telerik Academy", Location = "Sofia" };

            var firstMark = new Mark() { Subject = "math", Value = 5.00 };
            var secondMark = new Mark() { Subject = "c#", Value = 6.00 };
            var thirdMark = new Mark() { Subject = "js", Value = 5.00 };
            var fourthMark = new Mark() { Subject = "css", Value = 4.00 };

            var student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = 21,
                School = school,
                Grade = 12,
                Marks = new List<Mark>() { firstMark, secondMark, thirdMark, fourthMark }
            };

            return student;
        }
    }
}
