using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    class Messages
    {
        public static void Greetings()
        {
            Console.WriteLine($"Hello, it is {DateTime.Now.ToString("HH:mm")} o`clock. \nNice to hear you.\n\nWhat is your name?");
        }

        public static void ByeBye(Customer customer)
        {
            Console.WriteLine($"Thanks for the order. The details was sent to your mail {customer.Email} ");
        }

    }
}
