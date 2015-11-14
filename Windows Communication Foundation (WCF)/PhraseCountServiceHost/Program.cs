namespace PhraseCountServiceHost
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using StringCountService;

    class PhraseCountServiceHost
    {

        static void Main()
        {

            Uri serviceAddress = new Uri("http://localhost:3000/phraseCount");

            ServiceHost selfHost = new ServiceHost(typeof(PhraseCount), serviceAddress);

            var smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            selfHost.Description.Behaviors.Add(smb);

            using (selfHost)
            {
                selfHost.Open();

                Console.WriteLine("The service is started at endpoint " + serviceAddress);
                Console.WriteLine("Press enter to exit.");
                Console.ReadLine();
            }
        }
    }
}