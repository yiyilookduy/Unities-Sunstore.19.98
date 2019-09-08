using System;
using System.Collections.Generic;
using System.Text;

namespace Unities_Sunstore._19._98.BL.Features
{
    class LineForBump : IFeatures
    {
        public void Do()
        {
            

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
