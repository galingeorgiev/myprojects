using System;

namespace _07.ObjectAndCastExercise
{
    class Program
    {
        static void Main()
        {
            string wordHello = "Hello";
            string wordWorld = "World";
            object helloWorld = wordHello + " " + wordWorld;
            string helloWorldString = (string)helloWorld;
        }
    }
}
