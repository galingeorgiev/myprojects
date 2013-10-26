using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LocalRedis
{
    public static class Extensions
    {
        public static byte[] ToAsciiCharArray(this string s)
        {
            byte[] array = new byte[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                array[i] = (byte)(((int)s[i]) % 256);
            }

            return array;
        }

        public static string StringFromByteArray(byte[] arr)
        {
            StringBuilder sb = new StringBuilder(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append((char)arr[i]);
            }

            return sb.ToString();
        }
    }

    public class User
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public List<Message> Messages { get; set; }
    }

    public class Message
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public User Sender { get; set; }
        public User Recipient { get; set; }
    }

    public class Chat
    {
        public string Id { get; set; }
        public List<Message> Messages { get; set; }
    }

    class LocalRedisNSAChat
    {
        static void PrintMessages(RedisClient redisClient, string userA, string userB)
        {
            string chatName = userA.CompareTo(userB) < 0 ? userA+ "-" + userB: userB + "-" + userA;
            string chatMessagesList = "chat:" + chatName;
            byte[][] messages = redisClient.LRange(chatMessagesList, 0, (int)redisClient.LLen(chatMessagesList));

            foreach (var messageByteArr in messages)
            {
                string usernameStr = Extensions.StringFromByteArray(messageByteArr);
                Console.WriteLine(usernameStr);
            }
        }

        static void PrintUsers(RedisClient redisClient)
        {
            byte[][] usernames = redisClient.SMembers("usernames");
            foreach (var usernameByteArr in usernames)
            {
                string usernameStr = Extensions.StringFromByteArray(usernameByteArr);
                Console.WriteLine(usernameStr);
            }
        }

        static void PrintMenu(RedisClient redisClient, string username, string otherUsername)
        {
            if (otherUsername == null)
            {
                Console.WriteLine("Chat with:");
                PrintUsers(redisClient);
                Console.WriteLine();
                Console.WriteLine("Type the name of any user to enter a chat with them:");
            }
            else
            {
                Console.WriteLine("Messages:");
                PrintMessages(redisClient, username, otherUsername);
            }
        }

        static bool TryCreateUser(string username, RedisClient redisClient)
        {
            if (redisClient.SAdd("usernames", username.ToAsciiCharArray()) != 0)
            {
                Console.WriteLine("Please enter your age:");
                int age = int.Parse(Console.ReadLine());
                //Think about potential race conditions
                redisClient.HSetNX("user:" + username, "username".ToAsciiCharArray(), username.ToAsciiCharArray());
                redisClient.HSetNX("user:" + username, "age".ToAsciiCharArray(), age.ToString().ToAsciiCharArray());
                return true;
            }

            return false;
        }

        static void Main(string[] args)
        {
            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                Console.WriteLine("Hello, Welcome to NSA Chat. Feel free to communicate, we won't eavesdrop!");
                Console.WriteLine("Please login with a username (will be created if it doesn't exist):");

                string username = Console.ReadLine();

                if (TryCreateUser(username, redisClient))
                {
                    Console.WriteLine("Registered as " + username);
                }
                else
                {
                    Console.WriteLine("Logged in as " + username);
                }

                string otherUsername = null;

                while (true)
                {
                    PrintMenu(redisClient, username, otherUsername);
                    otherUsername = ProcessUserInput(redisClient, username, otherUsername);
                }
            }
        }

        private static string ProcessUserInput(RedisClient redisClient, string username, string otherUsername)
        {
            string input = Console.ReadLine();
            if (otherUsername == null)
            {
                if (redisClient.SIsMember("usernames", input.ToAsciiCharArray()) != 0)
                {
                    otherUsername = input;

                    return otherUsername;
                }
                else
                {
                    Console.WriteLine("Wrong username, try again!");
                    return null;
                }
            }
            else
            {
                if (input.ToLower() != "/exit")
                {
                    string chatName = username.CompareTo(otherUsername) < 0 ? username + "-" + otherUsername : otherUsername + "-" + username;
                    redisClient.RPush("chat:" + chatName, (username + ": " + input).ToAsciiCharArray());
                }
                else
                {
                    otherUsername = null;
                }

                return otherUsername;
            }
        }
    }
}
