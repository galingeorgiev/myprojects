using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortNumbers
{
    class Program
    {
        static void Main()
        {
            int firstVar = int.Parse(Console.ReadLine());
            int secondVar = int.Parse(Console.ReadLine());
            int thirdVar = int.Parse(Console.ReadLine());

            int temp1 = 0;
            int temp2 = 0;
            int temp3 = 0;

            if (firstVar < secondVar & secondVar < thirdVar)
            {
                temp1 = firstVar;
                temp2 = secondVar;
                temp3 = thirdVar;
            }
            else
            {
                if (secondVar < firstVar & firstVar < thirdVar)
                {
                    temp1 = secondVar;
                    temp2 = firstVar;
                    temp3 = thirdVar;
                }
                else
                {
                    if (thirdVar < firstVar & firstVar < secondVar)
                    {
                        temp1 = thirdVar;
                        temp2 = firstVar;
                        temp3 = secondVar;
                    }
                    else
                    {
                        if (secondVar < thirdVar & thirdVar < secondVar)
                        {
                            temp1 = secondVar;
                            temp2 = thirdVar;
                            temp3 = firstVar;
                        }
                        else
                        {
                            if (thirdVar < secondVar & secondVar < firstVar)
                            {
                                temp1 = thirdVar;
                                temp2 = secondVar;
                                temp3 = firstVar;
                            }
                            else
                            {
                                if (firstVar < thirdVar & thirdVar < secondVar)
                                {
                                    temp1 = firstVar;
                                    temp2 = thirdVar;
                                    temp3 = secondVar;
                                }
                                else
                                {
                                    if (firstVar > secondVar & secondVar < thirdVar)
                                    {
                                        temp1 = secondVar;
                                        temp2 = thirdVar;
                                        temp3 = firstVar;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("{0}\n{1}\n{2}", temp1, temp2, temp3);
        }
    }
}
