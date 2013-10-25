/* A text file students.txt holds information about students and their courses in the following format:
 * Kiril  | Ivanov   | C#
 * Stefka | Nikolova | SQL
 * Stela  | Mineva   | Java
 * Milena | Petrova  | C#
 * Ivan   | Grigorov | C#
 * Ivan   | Kolev    | SQL
 * 
 * Using SortedDictionary<K,T> print the courses in alphabetical order
 * and for each of them prints the students ordered by family and 
 * then by name:
 * 
 * C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
 * Java: Stela Mineva
 * SQL: Ivan Kolev, Stefka Nikolova
 */

namespace ReadFileAndPrintSortedInformation
{
    using System;
    using System.IO;
    using Wintellect.PowerCollections;

    public class TestFunctionality
    {
        public static void Main()
        {
            OrderedMultiDictionary<string, Student> coursesAndStudents = new OrderedMultiDictionary<string, Student>(true);
            
            string path = @"../../InputFile/students.txt";

            using (StreamReader fileReader = new StreamReader(path))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    string[] studentData = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string courseName = studentData[2].Trim();
                    string studentFirstName = studentData[0].Trim();
                    string studentLastName = studentData[1].Trim();

                    Student currentStudent = new Student(studentFirstName, studentLastName);

                    coursesAndStudents.Add(courseName, currentStudent);
                }
            }

            foreach (var course in coursesAndStudents)
            {
                Console.Write(course.Key + ": ");
                var students = coursesAndStudents[course.Key];
                Console.WriteLine(string.Join(", ", students));
            }
        }
    }
}
