using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    public class TimeOfDay
    {
        enum DayTime
        {
            Morning,
            Afternoon,
            Evening,
            Night
        }

        public static void GreetingsTimeOfDay(Customer customer)
        {
            DayTime timeOfDay = DayTime.Afternoon;
            if (DateTime.Now.Hour > 8 && DateTime.Now.Hour <= 12) timeOfDay = DayTime.Morning;
            else if (DateTime.Now.Hour > 12 && DateTime.Now.Hour <= 18) timeOfDay = DayTime.Afternoon;
            else if (DateTime.Now.Hour > 18 && DateTime.Now.Hour <= 24) timeOfDay = DayTime.Evening;
            else if (DateTime.Now.Hour > 0 && DateTime.Now.Hour <= 7) timeOfDay = DayTime.Night;
            Console.WriteLine($"Good {timeOfDay} {customer.Name}");
            Logger.Log(Logger.Level.Debug, $"Email sending. Txt: now is {DateTime.Now} and we say: {timeOfDay}");
        }
    }

}

