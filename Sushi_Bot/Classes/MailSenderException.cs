using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaBot.Classes
{
    class MailSenderException : Exception
    {
        public MailSenderException(string message) : base(message)
        {
        }
    }
}
