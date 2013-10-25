using System;
using System.Linq;
using System.Text;

class SupermarketQueue
{
    //static ISupermarketRepository repository = new SupermarketRepositorySlow();
    //static ISupermarketRepository repository = new SupermarketRepositoryMix();
	static ISupermarketRepository repository = new SupermarketRepositoryFast();
	static StringBuilder result = new StringBuilder();

    static void Main()
    {
        string command = null;
        while (command != "End")
        {
            command = Console.ReadLine();
            ProcessCommand(command);
        }

        Console.WriteLine(result);
    }

    static void ProcessCommand(string command)
    {
        string[] commandParts = command.Split(' ');
        string commandName = commandParts[0];
        switch (commandName)
        {
            case "Append":
                string name = commandParts[1];
                ProcessAppendCommand(name);
                break;
            case "Insert":
                int position = int.Parse(commandParts[1]);
                name = commandParts[2];
                ProcessInsertCommand(position, name);
                break;
            case "Find":
                name = commandParts[1];
                ProcessFindCommand(name);
                break;
            case "Serve":
                int count = int.Parse(commandParts[1]);
                ProcessServeCommand(count);
                break;
            case "End":
                break;
            default:
                throw new InvalidOperationException("Invalid command: " + command);
        }
    }

    private static void ProcessAppendCommand(string name)
    {
        repository.Append(name);
        result.AppendLine("OK");
    }

    private static void ProcessInsertCommand(int position, string name)
    {
        try
        {
            repository.Insert(position, name);
            result.AppendLine("OK");
        }
        catch (Exception)
        {
            result.AppendLine("Error");
        }
    }

    private static void ProcessFindCommand(string name)
    {
        int occurences = repository.Find(name);
        result.AppendLine(occurences.ToString());
    }

    private static void ProcessServeCommand(int count)
    {
        try
        {
            var servedNames = repository.Serve(count);
            string servedNamesStr = string.Join(" ", servedNames);
            result.AppendLine(servedNamesStr);
        }
        catch (Exception)
        {
            result.AppendLine("Error");
        }
    }
}
