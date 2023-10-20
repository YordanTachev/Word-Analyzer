using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Homewrok2
{
    internal class Program
    {

        static string fileName = "Book.txt";
        static string fullPath = Path.GetFullPath(fileName);
        static StreamReader text1 = new StreamReader(@fullPath);
        static string text=text1.ReadToEnd();
        static List<string> words = new List<string>();
        static string WS;
        static string WL;
        static double avrL;
        static List<string> revL = new List<string> ();

        static void wordsCount()
        {
            Console.WriteLine("Count of words:" + words.Count);

            var shortestWord = words[0];
            for (int i = 1; i < words.Count; i++)
            {
                if (shortestWord.Length > words[i].Length)
                {
                    shortestWord = words[i];
                    WS = shortestWord;
                }
            }
        }

        static void shortWord()
        {
            string shortestWord = WS;
            Console.WriteLine("Shortest word:" + shortestWord);
            Console.WriteLine();

            var longestWord = words[0];
            for (int i = 1; i < words.Count; i++)
            {
                if (longestWord.Length < words[i].Length)
                {
                    longestWord = words[i];
                    WL = longestWord;
                }
            }
        }

        static void longesWord()
        {
            string longestWord = WL;
            Console.WriteLine("longestWord:" + longestWord);
            Console.WriteLine();

            var avarage = 0.0;
            for (int i = 1; i < words.Count; i++)
            {
                avarage += (words[i].Length + 0.0) / words.Count;
                avrL = avarage;
            }
        }

        static void averageLenght()
        {
            double avarage = avrL;
            Console.WriteLine("Average:" + avarage);
            Console.WriteLine();

            var ocurrancies = new Dictionary<string, int>();

            for (int i = 1; i < words.Count; i++)
            {
                if (ocurrancies.ContainsKey(words[i]))
                {
                    ocurrancies[words[i]] = ocurrancies[words[i]] + 1;
                }
                else
                {
                    ocurrancies.Add(words[i], 1);
                }
            }
        }

        static void leatUsed5()
        {
            double avarage = avrL;
            var ocurrancies = new Dictionary<string, int>();

            for (int i = 1; i < words.Count; i++)
            {
                if (ocurrancies.ContainsKey(words[i]))
                {
                    ocurrancies[words[i]] = ocurrancies[words[i]] + 1;
                }
                else
                {
                    ocurrancies.Add(words[i], 1);
                }
            }
            var reverse = new Dictionary<int, List<string>>();
            var enumer = ocurrancies.GetEnumerator();

            while (enumer.MoveNext())
            {
                var curr = enumer.Current;
                if (reverse.ContainsKey(curr.Value))
                {
                    reverse[curr.Value].Add(curr.Key);
                }
                else
                {
                    reverse[curr.Value] = new List<string>() { curr.Key };

                }
            }
            Console.WriteLine("Least five words used");
            var t = new List<int>(reverse.Keys).ToArray();
            Array.Sort(t);
            var showed = 0;
            for (int i = 0; i < Math.Min(5, t.Length) && showed < 5; i++)
            {
                foreach (var element in reverse[t[i]])
                {
                    Console.WriteLine(element + " " + t[i]);
                    showed++;
                }
            }

        }
        static void mostUsed5()
        {
            double avarage = avrL;
            var ocurrancies = new Dictionary<string, int>();
            for (int i = 1; i < words.Count; i++)
            {
                if (ocurrancies.ContainsKey(words[i]))
                {
                    ocurrancies[words[i]] = ocurrancies[words[i]] + 1;
                }
                else
                {
                    ocurrancies.Add(words[i], 1);
                }
            }
            var reverse = new Dictionary<int, List<string>>();
            var enumer = ocurrancies.GetEnumerator();
            while (enumer.MoveNext())
            {
                var curr = enumer.Current;
                if (reverse.ContainsKey(curr.Value))
                {
                    reverse[curr.Value].Add(curr.Key);
                }
                else
                {
                    reverse[curr.Value] = new List<string>() { curr.Key };
                }
            }
            var t = new List<int>(reverse.Keys).ToArray();
            Array.Sort(t);
            var showed = 0;
            
            Console.WriteLine("MOST words used");

            Array.Sort(t, (a, b) => b - a);
            showed = 0;
            for (int i = 0; i < Math.Min(5, t.Length) && showed < 5; i++)
            {
                foreach (var element in reverse[t[i]])
                {
                    Console.WriteLine(element + " " + t[i]);
                    showed++;
                }
            }
        }
        static void Main(string[] args)
        {

            var wordState = "";
            Regex rx = new Regex(@"[a-zA-Z0-9а-яА-Я]");
            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];
                if (rx.Match(c + "").Success)
                {
                    wordState += c;
                    if (i == text.Length - 1)
                    {
                        words.Add(wordState);
                    }
                }
                else
                {
                    if (wordState.Length >= 3)
                    {
                        words.Add(wordState);
                    }
                    wordState = "";
                }


                
            }



            Thread count = new Thread(wordsCount);
            count.Start();
            Console.WriteLine();

            Thread TH2 = new Thread(shortWord);
            TH2.Start();
            Console.WriteLine();

            Thread TH3 = new Thread(longesWord);
            TH3.Start();
            Console.WriteLine();
            Thread TH4 = new Thread(averageLenght);
            TH4.Start();
            Console.WriteLine();
            /*          
            Thread TH5 = new Thread(leatUsed5);
            TH5.Start();           
            */
            Console.WriteLine();
            Thread TH6 = new Thread(mostUsed5);
            TH6.Start();

            Console.WriteLine();
            Console.ReadLine();
        }
    }
}