using System;

public class MulticastDelegatesExample
{
    public delegate void StringDelegate(string value);

    public void PrintString(string value)
    {
        Console.WriteLine(value);
    }

    public void PrintStringLength(string value)
    {
        Console.WriteLine("Length = {0}", value.Length);
    }

    public static void PrintStringWithDate(string value)
    {
        Console.WriteLine("{0}: {1}", DateTime.Now, value);
    }

    public static void PrintInvocationList(Delegate someDelegate)
    {
        Console.Write("(");
        Delegate[] list = someDelegate.GetInvocationList();
        foreach (Delegate del in list)
        {
            Console.Write(" {0}", del.Method.Name);
        }
        Console.WriteLine(" )");
    }

    public static void Main()
    {
        MulticastDelegatesExample example = 
            new MulticastDelegatesExample();

        StringDelegate printDelegate =
            new StringDelegate(example.PrintString);

        PrintInvocationList(printDelegate);
        // Prints: ( PrintString )

        printDelegate = (StringDelegate)
            Delegate.Combine(printDelegate, printDelegate);
        PrintInvocationList(printDelegate);
        // Prints: ( PrintString PrintString )

        StringDelegate printLengthDelegate =
            new StringDelegate(example.PrintStringLength);

        StringDelegate printWithDateDelegate =
            new StringDelegate(PrintStringWithDate);

        StringDelegate combinedDelegate = (StringDelegate)
            Delegate.Combine(printDelegate, printLengthDelegate);

        PrintInvocationList(combinedDelegate);
        // Prints: ( PrintString PrintStringLength )

        combinedDelegate = (StringDelegate)
            Delegate.Combine(combinedDelegate, printWithDateDelegate);

        PrintInvocationList(combinedDelegate);
        // Prints: ( PrintString PrintStringLength PrintStringWithDate )

        // Invoke the delegate
        combinedDelegate("test");
    }
}
