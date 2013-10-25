using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PossibleCards
{
    class Program
    {
        static void Main()
        {
            //string[] kindCards = { "Diamonds", "Hearts", "Spades", "Clubs" };
            //string[] numberCards = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            for (int i = 0; i < 13; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    switch (i)
                    {
                        case 0:
                            Console.Write("2");
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("3");
                            Console.Write(" ");
                            break;
                        case 2:
                            Console.Write("4");
                            Console.Write(" ");
                            break;
                        case 3:
                            Console.Write("5");
                            Console.Write(" ");
                            break;
                        case 4:
                            Console.Write("6");
                            Console.Write(" ");
                            break;
                        case 5:
                            Console.Write("7");
                            Console.Write(" ");
                            break;
                        case 6:
                            Console.Write("8");
                            Console.Write(" ");
                            break;
                        case 7:
                            Console.Write("9");
                            Console.Write(" ");
                            break;
                        case 8:
                            Console.Write("10");
                            Console.Write(" ");
                            break;
                        case 9:
                            Console.Write("Jack");
                            Console.Write(" ");
                            break;
                        case 10:
                            Console.Write("Queen");
                            Console.Write(" ");
                            break;
                        case 11:
                            Console.Write("King");
                            Console.Write(" ");
                            break;
                        case 12:
                            Console.Write("Ace");
                            Console.Write(" ");
                            break;
                    }
                    switch (j)
                    {
                        case 0:
                            Console.WriteLine("Diamonds");
                            break;
                        case 1:
                            Console.WriteLine("Hearts");
                            break;
                        case 2:
                            Console.WriteLine("Spades");
                            break;
                        case 3:
                            Console.WriteLine("Clubs");
                            break;

                    }
                    //Console.WriteLine("{0} {1}", numberCards[i], kindCards[j]);
                }
                Console.WriteLine();
            }
        }
    }
}
