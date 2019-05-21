using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace PizzaBot.Classes
{
    class Logger
    {
        public enum Level
        {
            Debug,
            Info,
            Error
        }

        public static void Log(Level level, string message)
        {
            string dateTimeLog = DateTime.Now.ToString("yyyyMMdd");
            if (!File.Exists($"log {dateTimeLog}_0.txt"))
            {
                Properties.Settings.Default.counter = 0;
                Properties.Settings.Default.Save();
            }

            int counter;
            try
            {
                counter = Properties.Settings.Default.counter;
            }
            catch (Exception)
            {
                counter = 0;
            }

            string messageToFile;
            string dateTimeTxt = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
            string nameLog = $"log {dateTimeLog}_{counter}.txt";
            string threadCurrent = Thread.CurrentThread.ManagedThreadId.ToString();
            string nameNamespace = System.Reflection.Assembly.GetExecutingAssembly().EntryPoint.DeclaringType.Namespace.ToString();
            string methodName = new System.Diagnostics.StackTrace().GetFrame(1).GetMethod().Name;
            messageToFile = $" {dateTimeTxt} {level} \tLog calls from namespace {nameNamespace}. The method is {methodName}. Message: {message} Thread is {threadCurrent}";
            string filePath = $@"{nameLog}";
            long size = 0;

            try
            {
                size = new FileInfo(filePath).Length;
            }
            catch (Exception) { }

            if (size > 30000)
            {
                counter++;
                filePath = $"log {dateTimeLog}_{counter}.txt";

                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(messageToFile);
                }
                Properties.Settings.Default.counter = counter;
                Properties.Settings.Default.Save();
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(messageToFile);
                }
            }

        }
    }
}
