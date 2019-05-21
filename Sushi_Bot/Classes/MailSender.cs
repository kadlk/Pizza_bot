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
        public static string email;
        private static string _emailMessage;
        private static DateTime _dateTime;

        public static async Task SendEmailAsync(List<FoodInCart> foodInCart)
        {
            _dateTime = DateTime.Now.ToLocalTime();
            _emailMessage = FoodInCart.CheckSummaryToEmail(foodInCart);
            _emailMessage += $"\n\n<br />Order was made : {_dateTime.ToShortDateString()} {_dateTime.ToShortTimeString()}";
            _emailMessage += $"\n<br />It will be delivered about : {_dateTime.AddMinutes(40).ToShortTimeString()}";

            Console.WriteLine("\nYour email");
            email = Console.ReadLine();


            MailAddress from = new MailAddress("mailforreg789@gmail.com", "MOE`S PUB");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Your order";
            message.Body = _emailMessage;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("mailforreg789@gmail.com", "Aspire7720gG");
            smtp.EnableSsl = true;

            await smtp.SendMailAsync(message);
            Logger.Log(Logger.Level.Debug, $"Email sending Async. With txt: {message}");

        }
        public static void SendEmail(List<FoodInCart> foodInCart)
        {
            _dateTime = DateTime.Now.ToLocalTime();
            _emailMessage = FoodInCart.CheckSummaryToEmail(foodInCart);
            _emailMessage += $"\n\nOrder was made : {_dateTime.ToShortDateString()} {_dateTime.ToShortTimeString()}";
            _emailMessage += $"\nIt will be delivered about : {_dateTime.AddMinutes(40).ToShortTimeString()}";
            Console.WriteLine("Your email");
            email = Console.ReadLine();

            MailAddress from = new MailAddress("mailforreg789@gmail.com", "MOE`S PUB");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Your order";
            message.Body = _emailMessage;
            message.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("mailforreg789@gmail.com", "Aspire7720gG");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(message);
                Logger.Log(Logger.Level.Debug, $"Email sending. With txt: {message}");
            }
            catch (Exception)
            {
                Logger.Log(Logger.Level.Error, "Email error: no internet");
                throw new MailSenderException("No internet connection");
            }
        }
    }
}
