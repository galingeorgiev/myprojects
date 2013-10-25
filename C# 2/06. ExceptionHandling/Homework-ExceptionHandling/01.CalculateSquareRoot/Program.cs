using System;

class Program
{
    static void Main()
    {
        Console.Write("N = ");
        try
        {
            int n = int.Parse(Console.ReadLine());
            double result = Math.Sqrt((int)n);
            if (double.IsNaN(result))
            {
                Console.WriteLine("You try to work with negative value.\nSquare root work only with positive values!");
                return;
            }
            Console.WriteLine("Square root of {0} is {1:F2}", n, result);
        }
        catch (OverflowException oe)
        {
            Console.Error.WriteLine("Exception: {0}\nPleace enter valid integer number between 0 - {1}\n", oe.Message, int.MaxValue);
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Exception: {0}\nPleace enter valid integer number between 0 - {1}\n", fe.Message, int.MaxValue);
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}