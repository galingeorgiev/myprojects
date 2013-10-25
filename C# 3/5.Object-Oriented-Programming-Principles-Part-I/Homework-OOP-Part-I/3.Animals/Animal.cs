using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Animal : ISound
    {
        private string name;
        private int age;
        private Sex sex;

        public Animal(string name, int age, Sex sex)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }

        public string Name
        {
            get { return this.name; }
        }

        public int Age
        {
            get { return this.age; }
        }

        public Sex Sex
        {
            get { return this.sex; }
        }

        public virtual void Sound(string sound)
        {
            Console.WriteLine("{0} say: {1}", this.name, sound);
        }

        public static void AveargeAge(IEnumerable<Animal> animals)
        {
            var averageAge = from animal in animals
                             group animal by animal.GetType() into animalsGroup
                             select new { key = animalsGroup.Key, average = animalsGroup.Average(x => x.age) };
            foreach (var animal in averageAge)
            {
                Console.WriteLine("{0} - {1:f2}",animal.key.Name, animal.average);
            }
        }
    }
}
