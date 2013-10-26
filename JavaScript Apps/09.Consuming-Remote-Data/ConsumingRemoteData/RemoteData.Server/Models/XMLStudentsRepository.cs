using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RemoteData.Server.Models
{
    public class XMLStudentsRepository : IStudentsRepository
    {
        private readonly string StudentsXmlFilePath;
        private XDocument studentsXmlDocument;

        private XDocument StudentsXmlDocument
        {
            get
            {
                if (this.studentsXmlDocument == null)
                {
                    this.studentsXmlDocument = XDocument.Load(this.StudentsXmlFilePath);
                }
                return this.studentsXmlDocument;
            }
        }

        public XMLStudentsRepository(string path)
        {
            this.StudentsXmlFilePath = path;
            if (!File.Exists(this.StudentsXmlFilePath))
            {
                var stream = File.Create(this.StudentsXmlFilePath);
                using (stream)
                {
                    XDocument doc = new XDocument();
                    doc.Add(new XElement("students", new XAttribute("last-id", "0")));
                    doc.Save(stream);
                }
            }
        }

        public Student GetStudent(int studentId)
        {
            var id = studentId.ToString();
            var root = this.StudentsXmlDocument.Root;
            var studentElement = root.Elements("student").FirstOrDefault(st => st.Attribute("id").Value == id);
            if (studentElement == null)
            {
                throw new ArgumentNullException("Id", "No such studnet");
            }
            var student = this.ParseStudent(studentElement);
            return student;
        }

        public IEnumerable<Student> GetStudents()
        {
            var studentElements = this.StudentsXmlDocument.Root.Elements("student");
            var students =
                from studentElement in studentElements
                select this.ParseStudent(studentElement);
            return students;
        }

        public void AddStudent(Student student)
        {
            var id = int.Parse(this.StudentsXmlDocument.Root.Attribute("last-id").Value) + 1;
            this.StudentsXmlDocument.Root.Attribute("last-id").SetValue(id);

            var idAttribute = new XAttribute("id", id);
            var firstnameAttribute = new XAttribute("firstname", student.FirstName);
            var lastnameAttribute = new XAttribute("lastname", student.LastName);
            var markElements =
                (from mark in student.Marks
                 select new XElement("mark",
                     new XAttribute("subject", mark.Subject),
                     new XAttribute("score", mark.Score)));
            var marksElement = new XElement("marks", markElements);
            var studentElement = new XElement("student", idAttribute, firstnameAttribute, lastnameAttribute,
                marksElement);

            this.StudentsXmlDocument.Root.Add(studentElement);
            this.SaveDocument();
        }

        public void DeleteStudent(int id)
        {
            var studentId = id.ToString();
            var studentElement = this.StudentsXmlDocument.Root.Elements("student").FirstOrDefault(st => st.Attribute("id").Value == studentId);
            if (studentElement != null)
            {
                studentElement.Remove();
            }
            this.SaveDocument();
        }

        private void SaveDocument()
        {
            this.StudentsXmlDocument.Save(this.StudentsXmlFilePath);
        }

        private Student ParseStudent(XElement studentElement)
        {
            int id = int.Parse(studentElement.Attribute("id").Value);
            string firstname = studentElement.Attribute("firstname").Value;
            string lastname = studentElement.Attribute("lastname").Value;
            IEnumerable<Mark> marks =
                (from markElement in studentElement.Element("marks").Elements("mark")
                 select this.ParseMark(markElement));
            var student = new Student()
            {
                Id = id,
                FirstName = firstname,
                LastName = lastname,
                Marks = marks
            };
            return student;
        }

        private Mark ParseMark(XElement markElement)
        {
            var subject = markElement.Attribute("subject").Value;
            var score = double.Parse(markElement.Attribute("score").Value, System.Globalization.CultureInfo.InvariantCulture);
            var mark = new Mark()
            {
                Subject = subject,
                Score = score
            };
            return mark;
        }
    }
}