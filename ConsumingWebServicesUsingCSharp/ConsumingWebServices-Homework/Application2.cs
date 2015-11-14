namespace ConsumingWebServices_Homework
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;

    public partial class Application
    {
        public Application(WebClient webClient)
        {
            this.WebClient = webClient;
            this.WebClient.BaseAddress = "http://api.feedzilla.com/v1/";
        }
                
        public WebClient WebClient { get; set; }

        public void PrintWebClientResults()
        {
            try
            {
                var response = this.WebClient.DownloadString(this.RequestURL);
                var articles = JsonConvert.DeserializeObject<IEnumerable<Article>>(response);
                this.Display(articles);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
