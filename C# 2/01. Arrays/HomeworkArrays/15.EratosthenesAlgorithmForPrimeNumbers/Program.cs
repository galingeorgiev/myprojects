using System;

class Program
{
    static void Main()
    {
        int lenght = 10000000;
        int[] arr = new int[lenght];
        for (int i = 0; i < lenght; i++)
        {
            arr[i] = i;
        }

        int counter = 2;
        bool stop = true;

        while (stop)
        {
            Console.Write("{0} ", counter);

            for (int i = counter; i < lenght; i++)
            {
                if (arr[i] % counter == 0)
                {
                    arr[i] = 0;
                }
            }

            for (int i = counter; i < lenght; i++)
            {
                if (i == lenght - 1)
                {
                    stop = false;
                    break;
                }
                if (arr[i] != 0)
                {
                    counter = arr[i];
                    break;
                }
            }

        }
    }
}
/*
 * Version 2
 * using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int lenght = 10000000;
        int[] arr = new int[lenght];
        for (int i = 2; i < lenght; i++)
        {
            arr[i] = i;
        }

        int counter = 2;
        bool stop = true;
        int index = 0;

        Console.Write("{0} ", 2);

        while (stop)
        {
            

            for (int i = counter; i < arr.Length; i++)
            {
                if (arr[i] % counter == 0)
                {
                    arr[i] = 0;
                }
            }

            List<int> list = new List<int>(arr);
            list.RemoveAll(x => x == 0);
            arr = list.ToArray();

            Console.Write("{0} ", arr[index]);
            index++;
            counter++;

            if (counter == arr.Length + 2)
            {
                stop = false;
                break;
            }
        }
    }
}
*/