using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    public class FoodInCart
    {
        public Food Item { get; set; }
        public int Quantity { get; set; }

        public FoodInCart(Food item, int quantity)
        {
            Item = item;
            Quantity = quantity;
        }

        public static void ShowCheckSummary(List<FoodInCart> foodInCart)
        {
            int summaryPrice = 0;
            Console.WriteLine("Check summary :");
            foreach (var item in foodInCart)
            {
                Console.WriteLine($"{item.Item.Name} x{item.Quantity} = {item.Item.Price * item.Quantity}BYN");
                summaryPrice += item.Item.Price * item.Quantity;
            }
            Console.WriteLine($"Total = {summaryPrice}BYN or {summaryPrice.ToDollars(2.09).ToString("#.##")}$");
        }

        public static string CheckSummaryToString(List<FoodInCart> foodInCart)
        {
            string checkSummary;
            int summaryPrice = 0;

            checkSummary = "Check summary :";
            foreach (var item in foodInCart)
            {
                checkSummary += $"\n{item.Item.Name} x{item.Quantity} = {item.Item.Price * item.Quantity}BYN";
                summaryPrice += item.Item.Price * item.Quantity;
            }
            checkSummary += $"\nTotal = {summaryPrice}BYN or {summaryPrice.ToDollars(2.09).ToString("#.##")}$";

            return checkSummary;
        }
    }
}
