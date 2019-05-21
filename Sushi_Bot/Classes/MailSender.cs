using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace PizzaBot.Classes
{
    class MailSender
    {
        private static string _email;
        private static string _emailMessage;
        private static DateTime _dateTime;

        public static async Task SendEmailAsync(List<FoodInCart> foodInCart)
        {
            _dateTime = DateTime.Now.ToLocalTime();
            _emailMessage = FoodInCart.CheckSummaryToString(foodInCart);
            _emailMessage += $"\n\nOrder was made : {_dateTime.ToShortDateString()} {_dateTime.ToShortTimeString()}";
            _emailMessage += $"\nIt will be delivered about : {_dateTime.AddMinutes(40).ToShortTimeString()}";

            Console.WriteLine("Your email");
            _email = Console.ReadLine();

            MailAddress from = new MailAddress("vadimkontush@gmail.com", "MOE`S PUB");
            MailAddress to = new MailAddress(_email);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Your order";
            message.Body = _emailMessage;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("vadimkontush@gmail.com", "Aspire7720gGNazi-suki");
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(message);
        }
        public static void SendEmail(List<FoodInCart> foodInCart)
        {
            _dateTime = DateTime.Now.ToLocalTime();
            _emailMessage = FoodInCart.CheckSummaryToString(foodInCart);
            _emailMessage += $"\n\nOrder was made : {_dateTime.ToShortDateString()} {_dateTime.ToShortTimeString()}";
            _emailMessage += $"\nIt will be delivered about : {_dateTime.AddMinutes(40).ToShortTimeString()}";
            Console.WriteLine("Your email");
            _email = Console.ReadLine();

            MailAddress from = new MailAddress("vadimkontush@gmail.com", "MOE`S PUB");
            MailAddress to = new MailAddress(_email);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Your order";
            message.Body = _emailMessage;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("vadimkontush@gmail.com", "Aspire7720gGNazi-suki");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(message);
            }
            catch (Exception)
            {
                throw new MailSenderException("No internet connection");
            }
        }
    }
}
