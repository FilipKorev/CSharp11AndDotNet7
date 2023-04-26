using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace quiz
{
   
    public class Options
    {
        public static string QOptions()
        {
            Console.WriteLine("What is the type of quiz you would like to take?");
            Console.WriteLine("1.Geography");
            Console.WriteLine("2.Maths");
            string userInput = Console.ReadLine().ToLower().Trim();
            return userInput;
        }
    }
}
