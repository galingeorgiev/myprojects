/* Create a class Person with two fields – name and age. Age can
 * be left unspecified (may contain null value. Override ToString()
 * to display the information of a person and if age is not
 * specified – to say so. Write a program to test this functionality. */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.Person
{
    class Person
    {
        private string name;
        private int? age;

        public Person(string name)
        {
            this.name = name;
        }

        public int? Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public override string ToString()
        {
            return string.Format("Name: {0} - Age: {1}", this.name, this.age == null ? 0 : this.age);
        }
    }
}
