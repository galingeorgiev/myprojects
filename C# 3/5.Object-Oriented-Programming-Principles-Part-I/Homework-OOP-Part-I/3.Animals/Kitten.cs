using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Kitten : Cat
    {
        private const Sex sex = Sex.Female;

        public Kitten(string name, int age)
            : base(name, age, sex)
        {
        }
    }
}
