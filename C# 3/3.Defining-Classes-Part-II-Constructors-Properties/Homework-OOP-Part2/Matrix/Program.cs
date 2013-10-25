using System;

namespace Matrix
{
    class Program
    {
        static void Main()
        {
            //Create two matrixs
            Matrix<int> firstMatrix = new Matrix<int>(2,2);
            Matrix<int> secondMatrix = new Matrix<int>(2,2);
            //1 3
            //2 4
            firstMatrix[0, 0] = 1;
            firstMatrix[1, 0] = 2;
            firstMatrix[0, 1] = 3;
            firstMatrix[1, 1] = 4;
            //5 7
            //6 8
            secondMatrix[0, 0] = 5;
            secondMatrix[1, 0] = 6;
            secondMatrix[0, 1] = 7;
            secondMatrix[1, 1] = 8;

            Matrix<int> result = new Matrix<int>(2,2);
            result = firstMatrix + secondMatrix;
            Console.WriteLine("{0} {1}", result[0, 0], result[0, 1]); //6 10
            Console.WriteLine("{0} {1}", result[1, 0], result[1, 1]); //8 12

            result = firstMatrix - secondMatrix;
            Console.WriteLine("{0} {1}", result[0, 0], result[0, 1]); //-4 -4
            Console.WriteLine("{0} {1}", result[1, 0], result[1, 1]); //-4 -4

            result = firstMatrix * secondMatrix;
            Console.WriteLine("{0} {1}", result[0, 0], result[0, 1]); //18 24
            Console.WriteLine("{0} {1}", result[1, 0], result[1, 1]); //24 32

            if (firstMatrix)
            {
                Console.WriteLine("Matrix is true!");
            }
            else
            {
                Console.WriteLine("Matrix is false!");
            }

            firstMatrix[0, 0] = 0;
            if (firstMatrix)
            {
                Console.WriteLine("Matrix is true!");
            }
            else
            {
                Console.WriteLine("Matrix is false!");
            }
        }
    }
}
