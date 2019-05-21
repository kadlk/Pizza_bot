using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    public class Customer
    {
        public string Name { get; set; }
        public string Order { get; set; }
        public int Cost { get; set; }
        public DateTime OrderDate { get; set; }
        public string DeliveryPlace { get; set; }
        public string Email { get; set; }
    }
}
