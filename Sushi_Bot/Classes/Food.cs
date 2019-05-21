using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    public class Food
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public virtual string ShowProduct()
        {
            return "";
        }

        public static void ShowMenu(List<Food> foods)
        {
            Console.WriteLine("\nOur menu today :");
            int i = 1;
            foreach (var item in foods)
            {
                Console.WriteLine($"{i}. {item.ShowProduct()}");
                i++;
            }
        }
    }

    public class Pizza : Food
    {
        public string Composition { get; set; }
        public int Weight { get; set; }

        public override string ShowProduct()
        {
            base.ShowProduct();
            return $"Pizza {Name}, price {Price}, Composition {Composition} and Weight {Weight}";
        }

        public Pizza(string name, int price, string composition, int weight)
        {
            Name = name;
            Price = price;
            Composition = composition;
            Weight = weight;
        }
    }

    public class Drink : Food
    {
        public int Milliliters { get; set; }

        public override string ShowProduct()
        {
            base.ShowProduct();
            return $"Drink is {Name}, price {Price} and Volume {Milliliters}mm";
        }

        public Drink(string name, int price, int milliliters)
        {
            Name = name;
            Price = price;
            Milliliters = milliliters;
        }
    }


}
