using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Dog : Animal
    {
        public Dog(string name, int age, Sex sex)
            : base(name, age, sex)
        {
        }

        public override void Sound(string sound = "bayyyyyyyy")
        {
            Console.WriteLine("{0} say: {1}", this.Name, sound);
        }
    }
}
