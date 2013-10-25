using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Person
{
    class TestPerson
    {
        static void Main()
        {
            //Create new person and print on console
            Person testPerson = new Person("Nakov");
            Console.WriteLine(testPerson);

            //Set explicitly age to null and print result
            testPerson.Age = null;
            Console.WriteLine(testPerson);

            //Set age with real number
            testPerson.Age = 30;
            Console.WriteLine(testPerson);
        }
    }
}
