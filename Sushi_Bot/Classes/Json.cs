using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace PizzaBot.Classes
{
    class Json
    {
        public static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };

        public static void Serializing(JsonSerializerSettings settings, string path)
        {
            List<Food> foods = new List<Food>();
            foods.Add(new Pizza("Margarita", 15, "meat+veg", 980));
            foods.Add(new Pizza("Barbeku", 18, "meat", 900));
            foods.Add(new Pizza("Students", 9, "sausages", 700));
            foods.Add(new Drink("Beer", 5, 500));
            foods.Add(new Drink("Cola", 4, 500));

            string output = JsonConvert.SerializeObject(foods, settings);
            File.WriteAllText(path, output);
            Logger.Log(Logger.Level.Debug, $"Serialazed products. To {path}");
        }

        public static List<Food> Deserealizing(JsonSerializerSettings settings, string path)
        {
            string jsonRead = System.IO.File.ReadAllText(path);
            List<Food> deserializedFood = JsonConvert.DeserializeObject<List<Food>>(jsonRead, settings);
            Logger.Log(Logger.Level.Debug, $"Deserialazed products. From {path}");
            return deserializedFood;
        }

        public static void SerializingCustomer(JsonSerializerSettings settings, string path, Customer customer)
        {
            string output = JsonConvert.SerializeObject(customer, settings);
            File.AppendAllText(path, output + Environment.NewLine);
            Logger.Log(Logger.Level.Debug, $"Serialazed products. To {path}");
        }
    }
}
