using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unities_Sunstore._19._98.BL;
using System.Runtime.InteropServices;
using Unities_Sunstore._19._98.BL.Features;

namespace Unities_Sunstore._19._98
{
    class Program
    {
        private static ConsoleKeyInfo userChoice;


        static void Main(string[] args)
        {

            // Declare
            Console.WriteLine("Hello Unities for Sunstore.19.98!");
            Console.OutputEncoding = Encoding.UTF8;
            userChoice = new ConsoleKeyInfo();

            var instance = RandomBL.Instance;
            Dictionary<ConsoleKey,IFeatures> dictionary = new Dictionary<ConsoleKey, IFeatures>();

            dictionary.Add(ConsoleKey.D1, new LineForBump());
            AskUserForSelectFeatures();



            while (userChoice.Key != ConsoleKey.Escape)
            {
                dictionary[userChoice.Key].Do();
                AskUserForSelectFeatures();
            }

        }

        static void AskUserForSelectFeatures()
        {
            Console.WriteLine("\n 1-- Get random string for comment up post");
            userChoice = Console.ReadKey();
        }
    }
}
