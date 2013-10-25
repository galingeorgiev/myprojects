/* Problem 2 from page below
 * http://academy.telerik.com/algoacademy/season-2012-2013/training-27-28-Oct-2012-combinatorics
 * You can test code in BGCODER
 * http://bgcoder.com/Contest/Practice/59
 * 02. Цветни зайци
 */

namespace ColorfulRabbits
{
    using System;
    using System.Collections.Generic;

    public class ColorfulRabbits
    {
        public static void Main()
        {
            Dictionary<int, int> rabbitsAnswers = new Dictionary<int, int>();
            int numberOfRabbitsAnswers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfRabbitsAnswers; i++)
            {
                int rabbitAnswer = int.Parse(Console.ReadLine());

                if (rabbitsAnswers.ContainsKey(rabbitAnswer + 1))
                {
                    rabbitsAnswers[rabbitAnswer + 1] = rabbitsAnswers[rabbitAnswer + 1] + 1;
                }
                else
                {
                    rabbitsAnswers.Add(rabbitAnswer + 1, 1);
                }
            }

            int result = 0;

            foreach (var answer in rabbitsAnswers)
            {
                if (answer.Key < answer.Value)
                {
                    result = result + ((int)Math.Ceiling((double)answer.Value / answer.Key) * answer.Key);
                }
                else
                {
                    result = result + answer.Key;
                }
            }

            Console.WriteLine(result);
        }
    }
}