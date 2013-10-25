using System;
using System.Collections.Generic;
using System.Text;

/* Add exception handling (where missing) and refactor all incorrect error handling in the code
 * from the "Exceptions-Homework" project to follow the best practices for using exceptions. */

private class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (count < 1)
        {
            throw new ArgumentException("Count must be greater from 1.");
        }

        if (startIndex >= arr.Length | startIndex < 0)
        {
            throw new ArgumentException("Start index is out of baundary of input array.");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentException("Start index plus count is out of baundary of input array.");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (count > str.Length)
        {
            throw new ArgumentException("Count must be less from lenght of input string.");
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static void CheckPrime(int number)
    {
        bool isPrime = true;
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                Console.WriteLine("The number {0} is not prime!", number);
                isPrime = false;
                break;
            }
        }

        if (isPrime)
        {
            Console.WriteLine("The number {0} is prime!", number);
        }
    }

    private static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        // This throw exception because we try to get empty array.
        // Uncomment to see result
        // var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        // Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));

        // This throw exception because we try to get substring with length greater from string lenght.
        // Uncomment to see result
        // Console.WriteLine(ExtractEnding("Hi", 100));

        CheckPrime(23);
        CheckPrime(33);
        
        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
