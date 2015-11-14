namespace ConsumingWebServices_Homework
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    
    public partial class Application
    {

        public Application()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.BaseAddress = new Uri("http://api.feedzilla.com/v1/");
            this.HttpClient.Timeout = TimeSpan.FromSeconds(3);
        }

        public string Query { get; set; }

        public int Count { get; set; }

        public HttpClient HttpClient { get; set; }

        public string RequestURL { get; set; }

        public void Start()
        {
            Console.WriteLine("Enter search term: ");
            this.Query = Console.ReadLine();
            Console.WriteLine("Enter the number of articles to retrieve: ");
            this.Count = int.Parse(Console.ReadLine());
            this.RequestURL = string.Format("categories/19/articles/search.json?q={0}&title_only=1&count={1}", this.Query, this.Count.ToString());
        }

        public void PrintResults()
        {
            PrintResults(this.HttpClient);
        }

        public async void PrintResults(HttpClient httpClient)
        {
            var response = await httpClient.GetAsync(this.RequestURL);
            // ?? Does not continue after this point! ??

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ReasonPhrase);
            }
            var articles = JsonConvert.DeserializeObject<IEnumerable<Article>>(await response.Content.ReadAsStringAsync());
            this.Display(articles);
        }

        public void Display(IEnumerable<Article> articles)
        {
            foreach (Article article in articles)
            {
                Console.WriteLine("Title: {0}", article.Title);
                Console.WriteLine("URL: {0}", article.URL);
            }
        }
    }
}
