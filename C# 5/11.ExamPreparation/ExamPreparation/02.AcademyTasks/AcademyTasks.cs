namespace AcademyTasks
{
    using System;

    public class AcademyTasks
    {
        private static int[] tasks;
        private static int varaety;
        private static int bestResult = int.MaxValue;

        public static void ReadInput()
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            varaety = int.Parse(secondLine);

            string[] tasksAsStrings = firstLine.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            tasks = new int[tasksAsStrings.Length];

            for (int i = 0; i < tasksAsStrings.Length; i++)
            {
                tasks[i] = int.Parse(tasksAsStrings[i]);
            }
        }

        public static void SolveAcademyTask()
        {
            for (int i = 0; i < tasks.Length - 1; i++)
            {
                for (int j = i + 1; j < tasks.Length; j++)
                {
                    if (Math.Abs(tasks[i] - tasks[j]) >= varaety)
                    {
                        int tasksCount = ((i + 1) / 2) + 1;
                        tasksCount = tasksCount + ((j - i + 1) / 2);
                        bestResult = Math.Min(bestResult, tasksCount);
                    }
                }
            }
        }

        public static void Main()
        {
            ReadInput();
            SolveAcademyTask();

            if (bestResult == int.MaxValue)
            {
                bestResult = tasks.Length;
            }

            Console.WriteLine(bestResult);
        }
    }
}