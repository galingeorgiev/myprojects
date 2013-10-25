using System;

class Program
{
    static void SideAndAltitude(double side, double altitude)
    {
        double surface = (side * altitude)/2;
        Console.WriteLine("Surface is: {0}", surface);
    }

    static void ThreeSides(double sideOne, double sideTwo, double sideThree)
    {
        double p = (sideOne + sideTwo + sideThree) / 2;
        double surface = Math.Sqrt(p * (p - sideOne) * (p - sideTwo) * (p - sideThree));
        Console.WriteLine("Surface is: {0}", surface);
    }

    static void TwoSidesAndAngel(double sideOne, double sideTwo, double angle)
    {
        double surface = (sideOne * sideTwo * Math.Sin(angle)) / 2;
        Console.WriteLine("Surface is: {0}", surface);
    }
    static void Main()
    {
        Console.Write("Press 1 for side and altitude\nPress 2 for three sides\nPress 3 for two sides and angel\nYour choice is: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                Console.Write("Side = ");
                double side = double.Parse(Console.ReadLine());
                Console.Write("Altitude = ");
                double altitude = double.Parse(Console.ReadLine());
                SideAndAltitude(side, altitude);
                break;
            case 2:
                Console.Write("Side one = ");
                double sideOne = double.Parse(Console.ReadLine());
                Console.Write("Side two = ");
                double sideTwo = double.Parse(Console.ReadLine());
                Console.Write("Side three = ");
                double sideThree = double.Parse(Console.ReadLine());
                ThreeSides(sideOne, sideTwo, sideThree);
                break;
            case 3:
                Console.Write("Side one = ");
                double sideOneOne = double.Parse(Console.ReadLine());
                Console.Write("Side two = ");
                double sideTwoTwo = double.Parse(Console.ReadLine());
                Console.Write("Angel = ");
                double angle = double.Parse(Console.ReadLine());
                TwoSidesAndAngel(sideOneOne, sideTwoTwo, angle);
                break;
            default:
                Console.WriteLine("Invalid value!\nPlease enter 1, 2 or 3");
                break;
        }
    }
}
