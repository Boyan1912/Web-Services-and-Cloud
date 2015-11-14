namespace DayOfWeekConsoleClient
{
    using System;
    using BGDayService;
    using System.Text;

    //02. Create a console-based client for the WCF service above. Use the "Add Service Reference" in Visual Studio.
    class Program
    {

        static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            var service = new DayOfWeekInBulgarianClient();

            Console.WriteLine("Днес е {0}", service.GetDayOfWeekInBulgarian(DateTime.Now));
        }
    }
}
