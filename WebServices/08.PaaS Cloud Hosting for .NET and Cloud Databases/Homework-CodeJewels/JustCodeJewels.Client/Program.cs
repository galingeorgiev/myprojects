using JustCodeJewels.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JustCodeJewels.Client
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient { BaseAddress = new Uri("http://localhost:50997/") };

        static void Main(string[] args)
        {
            var post = new Post() 
            { 
                SourceCode = "Console.WriteLine(\"Hello C#\");",
                AuthorMail = "SvetlinNakov@gmail.com", 
                Rating = 0,
                Category = "C#"
            };

            // Add post to database
            AddPost(post);

            // Get all posts
            var responseStr = Client.GetStringAsync("api/posts").Result;
            var posts = JsonConvert.DeserializeObject<IEnumerable<Post>>(responseStr);

            // If we have posts in db get one one update its rating
            if (posts != null)
            {
                // If vote = true this mean +1
                UpdateVode(posts.FirstOrDefault(), true);
            }

            // Print all posts
            PrintAllPosts();
        }

        public static void AddPost(Post post)
        {
            var response = Client.PostAsJsonAsync("api/posts", post).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post \"{0}\" added!", post.SourceCode);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void UpdateVode(Post post, bool vote)
        {
            string requestStr = string.Format("api/posts/{0}?vote={1}", post.PostId, vote);
            var response = Client.PutAsJsonAsync(requestStr, post).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Post \"{0}\" rating is updated!", post.SourceCode);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        public static void PrintAllPosts()
        {
            var responseStr = Client.GetStringAsync("api/posts").Result;

            var posts = JsonConvert.DeserializeObject <IEnumerable<Post>>(responseStr);

            foreach (var post in posts)
            {
                Console.WriteLine("Category: {0}; Rating: {1}; SourceCode: {2}; Author Mail: {3}\n",
                    post.Category,
                    post.Rating, 
                    post.SourceCode,
                    post.AuthorMail);
            }
        }
    }
}
