namespace ConsumingWebServices_Homework
{
    using System;
    using System.Net;

    class Program
    {
        static void Main()
        {
            // Not Tested, http://www.feedzilla.com/ is not working now!!!

            //var app = new Application();
            //app.Start();
            //app.PrintResults();

            WebClient webClient = new WebClient();
            var appTwo = new Application(webClient);
            appTwo.Start();
            appTwo.PrintWebClientResults();
        }
    }
}
