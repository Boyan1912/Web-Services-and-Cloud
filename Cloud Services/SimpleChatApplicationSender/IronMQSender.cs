namespace IronMQSimpleChatApplicationSender
{
    using IronMQ;
    using System;
    using System.IO;
    using System.Net;

    class IronMQSender
    {
        static void Main()
        {

            Client client = new Client("5648a0c173d0cd0006000090", "IxtQbuTA34qw1nmTDv75");

            Queue queue = client.Queue("Chat app");
            Console.WriteLine("Enter messages to be sent to the IronMQ server:");
            string ipAddress = GetSenderIpAddress();
            while (true)
            {
                string msg = Console.ReadLine();
                queue.Push(string.Format("{0}: {1}", ipAddress, msg));
                Console.WriteLine("Message sent to the IronMQ server.");
            }
            
        }

        static string GetSenderIpAddress()
        {
            // check IP using DynDNS's service
            WebRequest request = WebRequest.Create("http://checkip.dyndns.org");
            WebResponse response = request.GetResponse();
            StreamReader stream = new StreamReader(response.GetResponseStream());

            // read complete response
            string ipAddress = stream.ReadToEnd();

            // replace everything and keep only IP
            return ipAddress.
                Replace("<html><head><title>Current IP Check</title></head><body>Current IP Address: ", string.Empty).
                Replace("</body></html>", string.Empty).Trim();
        }
    }
}
