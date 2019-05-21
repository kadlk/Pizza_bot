using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    class Questions
    {
        public static void ChoosingFromMenu(List<Food> deserializedFood, List<FoodInCart> foodInCarts)
        {
            Logger logger = new Logger();
            logger.Log(Logger.Level.Error, "MESSAGE");
            string inputYesNo = "YES";
            while (inputYesNo.Equals("YES", StringComparison.OrdinalIgnoreCase))
            {
                string input;
                int positionChosen;
                int quantity;
                Console.WriteLine("Choose what you want");
                do
                {
                    input = Console.ReadLine();
                    bool result = int.TryParse(input, out positionChosen);
                    if (!(positionChosen > 0 && positionChosen < deserializedFood.Count + 1)) Console.WriteLine("Wrong position. One more try");
                }

                while (!(positionChosen > 0 && positionChosen < deserializedFood.Count + 1));

                do
                {
                    Console.WriteLine("How many items do you need?");
                    input = Console.ReadLine();
                    bool result = int.TryParse(input, out quantity);
                    if (!(quantity > 0 && quantity < 100)) Console.WriteLine("Wrong quantity. One more try");
                }
                while (!(quantity > 0 && quantity < 100));
                AddToCart(deserializedFood, positionChosen - 1, quantity, foodInCarts);

                Console.WriteLine("One more item? Type YES or NO");
                do
                {
                    inputYesNo = Console.ReadLine();
                    if (!(inputYesNo.Equals("YES", StringComparison.OrdinalIgnoreCase) || inputYesNo.Equals("NO", StringComparison.OrdinalIgnoreCase))) Console.WriteLine("Wrong answer. One more try. Type YES or NO.");
                }
                while (!(inputYesNo.Equals("YES", StringComparison.OrdinalIgnoreCase) || inputYesNo.Equals("NO", StringComparison.OrdinalIgnoreCase)));
            }
        }

        private static void AddToCart(List<Food> deserializedFood, int positionChosen, int quantity, List<FoodInCart> foodInCarts)
        {
            FoodInCart foodInCart = new FoodInCart(deserializedFood[positionChosen], quantity);
            foodInCarts.Add(foodInCart);
        }
    }
}



