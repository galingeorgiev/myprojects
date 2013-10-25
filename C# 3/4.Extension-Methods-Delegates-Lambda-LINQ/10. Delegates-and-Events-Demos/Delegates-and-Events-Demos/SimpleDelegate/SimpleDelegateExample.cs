using System;

public class SimpleDelegateExample
{
    // Declaration of a delegate
    delegate void SimpleDelegate(string param);

    public static void TestFunction(string param)
    {
        Console.WriteLine("I was called by a delegate.");
        Console.WriteLine("I got parameter {0}.", param);
    }

    public static void Main()
    {
        // Instantiation of а delegate
        SimpleDelegate d = new SimpleDelegate(TestFunction);
        
        // Invocation of the method, pointed by a delegate
        d("test");
    }
}
