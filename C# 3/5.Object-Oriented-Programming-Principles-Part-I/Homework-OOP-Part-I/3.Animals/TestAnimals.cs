/*Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define
 *useful constructors and methods. Dogs, frogs and cats are
 *Animals. All animals can produce sound (specified by the
 *ISound interface). Kittens and tomcats are cats. All animals
 *are described by age, name and sex. Kittens can be only female
 *and tomcats can be only male. Each animal produces a specific
 *sound. Create arrays of different kinds of animals and calculate
 *the average age of each kind of animal using a static method (you may use LINQ).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    class TestAnimals
    {
        static void Main()
        {
            //Create list of Animals
            //Tomcat and Kiten have constructor with only two parameters, third is constant
            Animal[] animals = new Animal[] {
            new Dog("Sharo",4,Sex.Male),
            new Cat("Kitty",3,Sex.Female),
            new Frog("Kyrmit",2,Sex.Male),
            new Kitten("Swetty",5),
            new Tomcat("Garfild",7),
            new Dog("Rex",3,Sex.Male),
            new Cat("Lussi", 6,Sex.Female),
            new Tomcat("SomeName",4)};

            Animal.AveargeAge(animals); //Print average age for every kind of animal in list
            
            animals[0].Sound("bayyyyyyyyyy");

            Cat myCat = new Cat("Garfild", 3, Sex.Female);
            myCat.Sound();

            Frog myFrog = new Frog("Kyrmit",3, Sex.Male);
            myFrog.Sound();
        }
    }
}
