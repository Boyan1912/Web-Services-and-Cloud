namespace PubNubSimpleChatApp
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    class Program
    {
        static void Main()
        {
            // Start the HTML5 Pubnub client
            Process.Start("..\\..\\PubNub-HTML5-Client.html");

            //System.Threading.Thread.Sleep(2000);

            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-a40489bf-98a7-40ff-87df-4af2f371d50a",               // PUBLISH_KEY
                "sub-c-68236eaa-8bb6-11e5-8b47-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-ZmVhNTE4NTgtYWRmYi00NGNjLWIzNjgtZjI1YTU2M2ZkMDU2",   // SECRET_KEY
                true                                                        // SSL_ON?
            );
            string channel = "demo-channel";

            // Publish a sample message to Pubnub
            List<object> publishResult = pubnub.Publish(channel, "Hello Pubnub!");
            Console.WriteLine(
                "Publish Success: " + publishResult[0].ToString() + "\n" +
                "Publish Info: " + publishResult[1]
            );

            // Show PubNub server time
            object serverTime = pubnub.Time();
            Console.WriteLine("Server Time: " + serverTime.ToString());

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate (object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }
                )
            );
            t.Start();

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish(channel, msg);
                Console.WriteLine("Message {0} sent.", msg);
            }
        }
    }
}
