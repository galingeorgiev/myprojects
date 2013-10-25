namespace Task2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Wintellect.PowerCollections;


    class Program
    {
        public static StringBuilder res = new StringBuilder();
        public static Queue<string> personsInQueue = new Queue<string>();
        public static List<string> persons = new List<string>();
        public static Dictionary<string, int> personsInDictionary = new Dictionary<string, int>();

        public static void ProcesCommand()
        {
            while (true)
            {
                string currentLine = Console.ReadLine();
                if (currentLine == "End")
                {
                    break;
                }

                string[] parametars = currentLine.Split(new char[] { ' ' });

                switch (parametars[0])
                {
                    case "Append":
                        personsInQueue.Enqueue(parametars[1]);
                        persons.Add(parametars[1]);
                        if (personsInDictionary.ContainsKey(parametars[1]))
                        {
                            personsInDictionary[parametars[1]] = personsInDictionary[parametars[1]] + 1;
                        }
                        else
                        {
                            personsInDictionary.Add(parametars[1], 1);
                        }

                        res.AppendLine("OK");
                        break;

                    case "Insert":
                        if (personsInDictionary.ContainsKey(parametars[2]))
                        {
                            personsInDictionary[parametars[1]] = personsInDictionary[parametars[2]] + 1;
                        }
                        else
                        {
                            personsInDictionary.Add(parametars[2], 1);
                        }

                        int position = int.Parse(parametars[1]);

                        if (personsInQueue.Count == position)
                        {
                            //persons.Clear();
                            //persons.AddRange(personsInQueue);
                            //personsInQueue.Clear();
                            //for (int i = 0; i < persons.Count; i++)
                            //{
                            //    personsInQueue.Enqueue(persons[i]);
                            //}
                            personsInQueue.Enqueue(parametars[2]);
                            res.AppendLine("OK");
                        }
                        else if (personsInQueue.Count > position)
                        {
                            persons.Clear();
                            persons.AddRange(personsInQueue);
                            personsInQueue.Clear();
                            for (int i = 0; i < persons.Count; i++)
                            {
                                if (i == position)
                                {
                                    personsInQueue.Enqueue(parametars[2]);
                                    personsInQueue.Enqueue(persons[i]);
                                }
                                else
                                {
                                    personsInQueue.Enqueue(persons[i]);
                                }
                            }

                            res.AppendLine("OK");
                        }
                        else
                        {
                            res.AppendLine("Error");
                        }
                        break;

                    case "Find":
                        if (personsInDictionary.ContainsKey(parametars[1]))
                        {
                            res.AppendLine(personsInDictionary[parametars[1]].ToString());
                        }
                        else
                        {
                            res.AppendLine("0");
                        }
                        break;

                    case "Serve":
                        int serveCount = int.Parse(parametars[1]);
                        if (personsInQueue.Count < serveCount)
                        {
                            res.AppendLine("Error");
                        }
                        else
                        {
                            for (int i = 0; i < serveCount; i++)
                            {
                                string currPerson = personsInQueue.Dequeue();

                                if (personsInDictionary.ContainsKey(currPerson))
                                {
                                    personsInDictionary[currPerson] = personsInDictionary[currPerson] - 1;

                                    if (personsInDictionary[currPerson] == 0)
                                    {
                                        personsInDictionary.Remove(currPerson);
                                    }
                                }

                                if (i == serveCount - 1)
                                {
                                    res.AppendLine(currPerson);
                                }
                                else
                                {
                                    res.Append(currPerson);
                                    res.Append(" ");
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        static void Main()
        {
            ProcesCommand();
            Console.WriteLine(res);
        }
    }
}
