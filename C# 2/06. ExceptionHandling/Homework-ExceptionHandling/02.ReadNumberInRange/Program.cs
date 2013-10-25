using System;

class Program
{
    static void ReadNumber(int start, int end, int number)
    {
        if (number < start | number >= end)
        {
            throw new ArgumentOutOfRangeException(string.Format("Number must be in range {0} - {1}\nNext element must be bigger from previous", start, end));
        }
        //Console.Write("{0} ", number);
    }

    static void Main()
    {
        int start = 1;
        int end = 100;

        try
        {
            Console.Write("Enter number: ");
            int number = int.Parse(Console.ReadLine());
            ReadNumber(start, end, number);
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.Write("a{0} = ", i + 1);
                number = int.Parse(Console.ReadLine());

                if (number > start)
                {
                    start = number;
                }
                ReadNumber(start, end, number);
            }
        }
        catch (ArgumentOutOfRangeException ae)
        {
            Console.Error.WriteLine(ae.Message);
        }
        catch (OverflowException oe)
        {
            Console.Error.WriteLine("Exception: {0}\nPleace enter valid integer number between {1} - {2}\n", oe.Message, start, end);
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Exception: {0}\nPleace enter valid integer number between {1} - {2}\n", fe.Message, start, end);
        }
    }
}