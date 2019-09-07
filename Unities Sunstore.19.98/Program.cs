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
        [DllImport("user32.dll")]
        internal static extern bool OpenClipboard(IntPtr hWndNewOwner);

        [DllImport("user32.dll")]
        internal static extern bool CloseClipboard();

        [DllImport("user32.dll")]
        internal static extern bool SetClipboardData(uint uFormat, IntPtr data);


        static void Main(string[] args)
        {

            // Declare
            Console.WriteLine("Hello Unities for Sunstore.19.98!");
            Console.OutputEncoding = Encoding.UTF8;
            var instance = RandomBL.Instance;
            ConsoleKeyInfo userChoice = new ConsoleKeyInfo();
            Dictionary<ConsoleKey,IFeatures> dictionary = new Dictionary<ConsoleKey, IFeatures>();

            dictionary.Add(ConsoleKey.A, new LineForBump());


            while (userChoice.Key != ConsoleKey.Escape)
            {
                Console.WriteLine("\n 1-- Get random string for comment up post");

                userChoice = Console.ReadKey();

                Console.Clear();
            
                if (userChoice.Key == ConsoleKey.D1)
                {
                    Console.WriteLine("Enter word do you want (number)");

                    if (Int32.TryParse(Console.ReadLine(), out int numOfWord))
                    {
                        Console.WriteLine("Enter line do you want (number)");

                        if (Int32.TryParse(Console.ReadLine(), out int numOfLine))
                        {
                            List<string> listString = instance.GetRandomResult(numOfWord, numOfLine).ToList();
                            StringBuilder result = new StringBuilder();

                            result.Append("{");
                            foreach (var flag in listString)
                            {
                                if (flag != listString.Last())
                                    result.Append(flag + "|");
                                else result.Append(flag);

                            }

                            result.Append("}");

                            Console.WriteLine(result.ToString());
                        }
                        else Console.WriteLine("Line is a number");
                        
                    }

                    else Console.WriteLine("Word is a number");


                    
                }
            }

        }
    }
}
