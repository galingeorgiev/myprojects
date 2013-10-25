using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolsHierarchy;
using System;

namespace SchoolHierarchy.Tests
{
    [TestClass]
    public class TestSchool
    {
        [TestMethod]
        public void JoinToCourse_AddThreeStudents()
        {
            School telerikAcademy = new School();

            Student nakov = new Student("Svetlin Nakov", 12345, telerikAcademy);
            Student doncho = new Student("Doncho Minkov", 23456, telerikAcademy);
            Student niki = new Student("Nikolay Kostov", 34567, telerikAcademy);

            Course oop = new Course();
            oop.JoinToCourse(nakov);
            oop.JoinToCourse(doncho);
            oop.JoinToCourse(niki);

            Assert.AreEqual(3, oop.CourseStudents.Count, "Wrong number of students in studentsList");
        }

        [TestMethod]
        public void LeaveCourse_TestAddThreeStudentsAndLeaveOne()
        {
            School telerikAcademy = new School();

            Student nakov = new Student("Svetlin Nakov", 12345, telerikAcademy);
            Student doncho = new Student("Doncho Minkov", 23456, telerikAcademy);
            Student niki = new Student("Nikolay Kostov", 34567, telerikAcademy);

            Course qpc = new Course();
            qpc.JoinToCourse(nakov);
            qpc.JoinToCourse(doncho);
            qpc.JoinToCourse(niki);

            qpc.LeaveCourse(nakov);

            Assert.AreEqual(2, qpc.CourseStudents.Count, "Wrong number of students in studentsList");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void JoinToCourse_ExceptionAddMoreFrom30Students()
        {
            School telerikAcademy = new School();
            Student nakov = new Student("Svetlin Nakov", 12345, telerikAcademy);
            Course html = new Course();
            for (int i = 0; i < 31; i++)
            {
                html.JoinToCourse(nakov);
            }
        }

        [TestMethod]
        public void StudentToString_TestWithOneNameAndID()
        {
            School telerikAcademy = new School();
            Student nakov = new Student("Svetlin Nakov", 12345, telerikAcademy);
            string expected = "Student name: Svetlin Nakov; Student ID: 12345";
            Assert.AreEqual(expected, nakov.ToString(), "Student method ToString() does not work correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentSetName_ExceptionEmptyName()
        {
            School telerikAcademy = new School();
            Student someStudent = new Student(string.Empty, 12345, telerikAcademy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentSetID_ExceptionIncorectIDWith4Digits()
        {
            School telerikAcademy = new School();
            Student someStudent = new Student("Student Name", 1234, telerikAcademy);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentSetID_DuplicatedStudentsIDException()
        {
            School telerikAcademy = new School();
            Student firstStudent = new Student("First Student", 12345, telerikAcademy);
            Student secondStudent = new Student("Second Student", 12345, telerikAcademy);
        }
    }
}
