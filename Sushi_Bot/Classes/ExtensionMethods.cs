using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    public static class ExtensionMethods
    {
        public static double ToDollars(this int value, double exchangeCourse)
        {
            return value / exchangeCourse;
        }
    }
}
