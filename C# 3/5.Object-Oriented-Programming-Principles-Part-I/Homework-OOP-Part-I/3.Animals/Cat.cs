using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Cat : Animal
    {
        public Cat(string name, int age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override void Sound(string sound = "miayyyyyyyy")
        {
            Console.WriteLine("{0} say: {1}", this.Name, sound);
        }
    }
}
