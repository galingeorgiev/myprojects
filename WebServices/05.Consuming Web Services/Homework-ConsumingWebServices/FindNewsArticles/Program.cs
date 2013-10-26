namespace FindNewsArticles
{
    using System;
    using System.Net.Http;

    class Program
    {
        static void Main()
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/categories/26/articles/");

            Console.WriteLine("Enter searhed word.");
            string searchedWord = Console.ReadLine();

            Console.WriteLine("Enter number of result that do you want to get(max 100).");
            string numberOfResults = Console.ReadLine();

            string request = "search.json?q=" + searchedWord + "&count=" + numberOfResults;

            var responseString = httpClient.GetAsync(request).Result.Content.ReadAsStringAsync().Result;

            var fzResult = Newtonsoft.Json.JsonConvert.DeserializeObject<FZResult>(responseString);

            if (fzResult.Articles.Count == 0)
            {
                Console.WriteLine("No results found!");
            }
            else
            {
                foreach (var article in fzResult.Articles)
                {
                    Console.WriteLine(article);
                }
            }
        }
    }
}