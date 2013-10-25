using System;

class SupermarketTestGenerator
{
	static Random rand = new Random();

	static void Main()
	{
		for (int i = 0; i < 100; i++)
		{
			Console.WriteLine("Append " + RandomWord());
			Console.WriteLine("Find " + RandomWord());
			Console.WriteLine("Insert " + rand.Next(5000 + i) + " " + RandomWord());
			Console.WriteLine("Insert 0 " + RandomWord());
		}
		for (int i = 0; i < 50; i++)
		{
			Console.WriteLine("Serve " + (1 + rand.Next(10)));
		}

		for (int i = 0; i < 50000; i++)
		{
			Console.WriteLine("Append " + RandomWord());
		}

		for (int i = 0; i < 50000; i++)
		{
			Console.WriteLine("Insert " + rand.Next(500 + i) + " " + RandomWord());
		}

		for (int i = 0; i < 100000; i++)
		{
			Console.WriteLine("Find " + RandomWord());
		}

		for (int i = 0; i < 50; i++)
		{
			Console.WriteLine("Serve " + (1 + rand.Next(100)));
		}

		Console.WriteLine("End");
	}

	private static string RandomWord()
	{
		string str = "" + (char)('A' + rand.Next(20));
		if (rand.Next(2) == 0)
		{
			str = str.ToLower();
		}
		str = str + rand.Next(100);
		return str;
	}
}
