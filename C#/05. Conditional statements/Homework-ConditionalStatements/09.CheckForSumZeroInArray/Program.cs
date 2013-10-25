using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.CheckForSumZeroInArray
{
    class Program
    {
        static void Main()
        {
            int[] arr = new int[5];
            for (int i = 0; i < arr.Length; i++)
            {
                int n = int.Parse(Console.ReadLine());
                arr[i] = n;
            }
            if (arr[0] + arr[1] == 0)
            {
                Console.WriteLine("{0}, {1}", arr[0], arr[1]);
            }
            else
            {
                if (arr[0] + arr[1] + arr[2] == 0)
                {
                    Console.WriteLine("{0}, {1}, {2}", arr[0], arr[1], arr[2]);
                }
                else
                {
                    if (arr[0] + arr[1] + arr[2] + arr[3] == 0)
                    {
                        Console.WriteLine("{0}, {1}, {2}, {3}", arr[0], arr[1], arr[2], arr[3]);
                    }
                    else
                    {
                        if (arr[0] + arr[1] + arr[2] + arr[3] + arr[4] == 0)
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", arr[0], arr[1], arr[2], arr[3], arr[4]);
                        }
                        else
                        {
                            if (arr[1] + arr[2] == 0)
                            {
                                Console.WriteLine("{0}, {1}", arr[1], arr[2]);
                            }
                            else
                            {
                                if (arr[1] + arr[2] + arr[3] == 0)
                                {
                                    Console.WriteLine("{0}, {1}, {2}", arr[1], arr[2], arr[3]);
                                }
                                else
                                {
                                    if (arr[1] + arr[2] + arr[3] + arr[4] == 0)
                                    {
                                        Console.WriteLine("{0}, {1}, {2}, {3}", arr[1], arr[2], arr[3], arr[4]);
                                    }
                                    else
                                    {
                                        if (arr[2] + arr[3] == 0)
                                        {
                                            Console.WriteLine("{0}, {1}", arr[2], arr[3]);
                                        }
                                        else
                                        {
                                            if (arr[2] + arr[3] + arr[4] == 0)
                                            {
                                                Console.WriteLine("{0}, {1}, {2}", arr[2], arr[3], arr[4]);
                                            }
                                            else
                                            {
                                                if (arr[3] + arr[4] == 0)
                                                {
                                                    Console.WriteLine("{0}, {1}", arr[3], arr[4]);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Don't find corect values");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
