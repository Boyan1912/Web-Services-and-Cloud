
namespace DayOfWeekService
{
    using System;
//   01. Create a simple WCF service. It should have a method that accepts a DateTime parameter and returns the day of week (in Bulgarian) as string.

//    Test it with the integrated WCF client.

    public class DayOfWeekInBulgarian : IDayOfWeekInBulgarian
    {
        public string GetDayOfWeekInBulgarian(DateTime value)
        {
            var day = (int)value.DayOfWeek;

            string result = "";
            switch (day)
            {
                case 0: result = "Неделя"; break;
                case 1: result = "Понеделник"; break;
                case 2: result = "Вторник"; break;
                case 3: result = "Сряда"; break;
                case 4: result = "Четвъртък"; break;
                case 5: result = "Петък"; break;
                case 6: result = "Събота"; break;
            }

            return result;
        }
        
    }
}
