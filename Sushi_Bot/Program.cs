using System;
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
            Logger.Log(Logger.Level.Info, "Info");
            Console.WriteLine($"Hello, it is {DateTime.Now.ToString("HH:mm")} o`clock. \nNice to hear you.\n\nWhat is your name?");
            Customer customer = new Customer();
            customer.Name = Console.ReadLine();
            TimeOfDay.GreetingsTimeOfDay(customer);
            
            Json.Serializing(Json.settings, @"menu.JSON");
            List<Food> deserializedFood = new List<Food>();
            deserializedFood = Json.Deserealizing(Json.settings, @"menu.JSON");
            Food.ShowMenu(deserializedFood);
            List<FoodInCart> foodInCarts = new List<FoodInCart>();
            Questions.ChoosingFromMenu(deserializedFood, foodInCarts);
            FoodInCart.ShowCheckSummary(foodInCarts);
            Console.WriteLine(FoodInCart.CheckSummaryToString(foodInCarts));
            MailSender.SendEmailAsync(foodInCarts).GetAwaiter();
            
            Console.ReadLine();
        }
    }
}
