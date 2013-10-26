using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace RemoteData.Server.Models
{
    public interface IStudentsRepository
    {
        Student GetStudent(int studentId);

        IEnumerable<Student> GetStudents();

        void AddStudent(Student student);

        void DeleteStudent(int id);
    }
}