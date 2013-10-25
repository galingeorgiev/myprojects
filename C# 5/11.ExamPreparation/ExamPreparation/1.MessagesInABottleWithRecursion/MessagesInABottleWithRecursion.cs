namespace MessagesInABottleWithRecursion
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class MessagesInABottleWithRecursion
    {
        private static string secretMessage;
        private static List<KeyValuePair<string, char>> cipher = new List<KeyValuePair<string, char>>();
        private static List<string> output = new List<string>();

        public static void ReadInput()
        {
            secretMessage = Console.ReadLine();

            string cipherString = Console.ReadLine();

            StringBuilder buildKey = new StringBuilder();
            for (int i = 0; i < cipherString.Length; i++)
            {
                if (cipherString[i] >= 'A' && cipherString[i] <= 'Z')
                {
                    char value = cipherString[i];
                    i++;

                    while (!(cipherString[i] >= 'A' && cipherString[i] <= 'Z'))
                    {
                        buildKey.Append(cipherString[i]);
                        i++;

                        if (i >= cipherString.Length)
                        {
                            break;
                        }
                    }

                    string key = buildKey.ToString();

                    cipher.Add(new KeyValuePair<string, char>(key, value));

                    buildKey.Clear();
                    i--;
                }
            }
        }

        public static void GenerateCombinations(StringBuilder currentWord, int currentIndex)
        {
            if (currentIndex == secretMessage.Length)
            {
                output.Add(currentWord.ToString());
                return;
            }

            for (int i = 0; i < cipher.Count; i++)
            {
                if (secretMessage.Substring(currentIndex).StartsWith(cipher[i].Key))
                {
                    GenerateCombinations(currentWord.Append(cipher[i].Value), currentIndex + cipher[i].Key.Length);
                    currentWord.Length--;
                }
            }
        }

        public static void Main()
        {
            ReadInput();
            GenerateCombinations(new StringBuilder(), 0);
            output.Sort();
            Console.WriteLine(output.Count);
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }
    }
}
