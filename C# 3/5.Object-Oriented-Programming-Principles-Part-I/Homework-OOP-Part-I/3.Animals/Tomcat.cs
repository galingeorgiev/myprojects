using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Tomcat : Cat
    {
        private const Sex sex = Sex.Male;

        public Tomcat(string name, int age)
            : base(name, age, sex)
        {
        }
    }
}
