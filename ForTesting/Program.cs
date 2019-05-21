using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace ForTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> pizzas = new List<string>();

            pizzas.Add("1");
            pizzas.Add("2");
            pizzas.Add("3");
            pizzas.Add("4");
            pizzas.Add("5");

            string output = JsonConvert.SerializeObject(pizzas);
            List<string> deserializedFood = JsonConvert.DeserializeObject<List<string>>(output);
            foreach (var item in deserializedFood)
            {
                Console.WriteLine(item);
            }

            //int x = 2;
            //int y = 3;

            //string input = "YES";
            ////if (!(input.Equals("YES", StringComparison.OrdinalIgnoreCase)) && !(input.Equals("NO", StringComparison.OrdinalIgnoreCase))) Console.WriteLine("Wrong answer. One more try");
            //if (!(x == 1) || !(y == 3)) Console.WriteLine("True 0 ");
            //if (x == 2 || y == 3)       Console.WriteLine("True 1 ");
            //if (x == 22 || y == 56)    Console.WriteLine("True 2 ");

            //if (!(x == 2))
            //{
            //    Console.WriteLine("True 3");
            //}
            Console.Read();
        }
    }
}
