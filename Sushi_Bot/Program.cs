﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using PizzaBot.Classes;


namespace PizzaBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Log(Logger.Level.Debug, "Program started");

            do
            {
                OneOrder();
                Console.WriteLine("One more client on call? YES or NO");
                Questions.inputYesNo = Console.ReadLine();
                if (!(Questions.inputYesNo.Equals("YES", StringComparison.OrdinalIgnoreCase) || Questions.inputYesNo.Equals("NO", StringComparison.OrdinalIgnoreCase)))
                {
                    do
                    {
                        Console.WriteLine("Wrong answer. One more try. Type YES or NO.");
                        Questions.inputYesNo = Console.ReadLine();

                    } while (!(Questions.inputYesNo.Equals("YES", StringComparison.OrdinalIgnoreCase) || Questions.inputYesNo.Equals("NO", StringComparison.OrdinalIgnoreCase)));
                }
            }
            while ((Questions.inputYesNo.Equals("YES", StringComparison.OrdinalIgnoreCase)));

            Console.Read();

            void OneOrder()
            {
                Logger.Log(Logger.Level.Debug, "Making order");
                Messages.Greetings();
                List<Customer> customers = new List<Customer>();
                customers.Add(new Customer() { Name = Console.ReadLine() });
                TimeOfDay.GreetingsTimeOfDay(customers[customers.Count - 1]);

                Json.Serializing(Json.settings, @"menu.JSON");
                List<Food> deserializedFood = new List<Food>();
                deserializedFood = Json.Deserealizing(Json.settings, @"menu.JSON");
                Food.ShowMenu(deserializedFood);
                List<FoodInCart> foodInCarts = new List<FoodInCart>();
                Questions.ChoosingFromMenu(deserializedFood, foodInCarts);
                FoodInCart.ShowCheckSummary(foodInCarts);

                MailSender.SendEmailAsync(foodInCarts).GetAwaiter();
                MailSender.SendEmail(foodInCarts);
                Console.WriteLine("Input your delivery adress");
                customers[customers.Count - 1].Adress = Console.ReadLine();
                customers[customers.Count - 1].Email = MailSender.email;
                customers[customers.Count - 1].OrderDate = DateTime.Now.ToLocalTime();
                customers[customers.Count - 1].Order = FoodInCart.CheckSummaryToString(foodInCarts);
                Json.SerializingCustomer(Json.settings, "Orders.Json", customers[customers.Count - 1]);
            }
        }
    }
}
