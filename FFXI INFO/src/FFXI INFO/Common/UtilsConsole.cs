using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFXI_INFO.Common
{
   public class UtilsConsole
    {
        public  bool Confirm(string title)
        {
            ConsoleKey response;
            do
            {
                Console.Write($"{ title } [y/n]" + Environment.NewLine);
                response = Console.ReadKey(false).Key;
                if (response != ConsoleKey.Enter)
                {
                    Console.WriteLine();
                }
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
        public   string GetAnswer(string question)
        {
            var ans = string.Empty;
            bool goodAns = false;
            do
            {
                ans = AskQuestion(question);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("You entered {0}. Is that correct? [y/n]", ans);
                Console.ForegroundColor = ConsoleColor.White;
                var confirm = Console.ReadLine();
                if (confirm.ToLower() == "y")
                    goodAns = true;
            } while (!goodAns);
            return ans;
        }
      public   string AskQuestion(string question)
        {
            
            Console.Write(question + Environment.NewLine);
            var ans = Console.ReadLine();
            return ans;
        }
    }
}