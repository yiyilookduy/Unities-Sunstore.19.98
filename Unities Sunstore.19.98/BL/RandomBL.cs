using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Unities_Sunstore._19._98.BL
{
    public class RandomBL
    {
        private static RandomBL _instance;
        private static List<string> _words;
        private static List<string> _defaultWords;
        private static List<string> mergeList;
        private static Random _random;

        protected RandomBL()
        {
            _words = File.ReadAllLines("word.txt")
                .Where(line => line.Length > 1).ToList();

            _defaultWords = File.ReadAllLines("default-word.txt")
                .Where(line => line.Length > 1).ToList();

            _random = new Random();

            mergeList = _words.Concat(_defaultWords).ToList();

        }

        public static RandomBL Instance
        {
            get { return _instance ?? (_instance = new RandomBL()); }
        }

        

        private IEnumerable<string> GetRandomWord()
        {
            while (true)
            {
                int num = _random.Next(mergeList.Count);
                yield return mergeList[num];
            }
        }

        public IEnumerable<string> GetRandomResult(int numOfWord, int numOfString)
        {
            StringBuilder string_b;

            while (numOfString >= 1)
            {
                string_b = new StringBuilder();
                for (int i = 0; i < numOfWord; i++)
                {
                    string_b.Append(GetRandomWord().First());
                }

                numOfString--;
                yield return string_b.ToString();
            }
        }
    }
}
