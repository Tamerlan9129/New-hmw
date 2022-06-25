using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AptekFinal_App.Helpers
{
    class Helper
    {
        public static void PrintSimple(string text, ConsoleColor color) 
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void SuccessAndError(string text, ConsoleColor color) 
        {
            Console.ForegroundColor = color;
            foreach (char item in text)
            {
                Console.Write(item);
                Thread.Sleep(35);

            }
            Console.WriteLine();
            Thread.Sleep(1000);
            Console.ResetColor();
        }


    }
}
