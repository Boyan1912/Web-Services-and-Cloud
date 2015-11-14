namespace PhraseCountServiceClient
{
    //Create a console client for the WCF service above.
    //Use the svcutil.exe tool to generate the proxy classes.

    using PhraseCountService;
    using System;

    //Start PhraseCountServiceHost\bin\Debug\PhraseCountServiceHost.exe as an Administrator for Server

    class Program
    {
        static void Main()
        {
            var service = new PhraseCountableClient();
            string text = "We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";
            string phrase = "in";

            Console.WriteLine("Text: {0}", text);
            Console.WriteLine("Search phrase: {0}", phrase);
            Console.WriteLine("The phrase \"{0}\" is contained {1} times in the text.", phrase, service.GetCount(phrase, text));
        }
    }
}
