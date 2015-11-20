namespace IronMQSimpleChatApplicationReceiver
{
    using IronMQ;
    using IronMQ.Data;
    using System;

    class IronMQReceiver
    {
        static void Main()
        {
            Client client = new Client("5648a0c173d0cd0006000090", "IxtQbuTA34qw1nmTDv75");

            Queue queue = client.Queue("Chat app");

            Console.WriteLine("Listening for new messages from IronMQ Server:");
            while (true)
            {
                Message msg = queue.Get();
                if (msg != null)
                {
                    Console.WriteLine(msg.Body);
                    queue.DeleteMessage(msg);
                }
            }
        }
    }
}
