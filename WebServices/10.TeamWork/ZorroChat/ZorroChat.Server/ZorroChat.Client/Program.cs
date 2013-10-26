using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZorroChat.Models;

namespace ZorroChat.Client
{
    class Program
    {
        private static readonly HttpClient Client = 
            new HttpClient { BaseAddress = new Uri("http://localhost:49657/") };

        static void Main(string[] args)
        {
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            User user = new User() { Username = "Pesho", Password = "123aaa" };

            var response = Client.PostAsJsonAsync("api/users", user).Result;
        }
    }
}
