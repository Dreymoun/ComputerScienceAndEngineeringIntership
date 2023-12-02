using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Module14.Homework.Counter
{
    class WordFrequency
    {
        static void Main(string[] args)
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Кото­рая в темном чулане хранится В доме, Который построил Джек. А это веселая птица­ синица, Которая часто вору­ет пшеницу, Которая в темном чулане хранится В доме, Который построил Джек";
            var wordCounts = CountWords(text);

            foreach (var pair in wordCounts)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value}");
            }
        }

        static Dictionary<string, int> CountWords(string text)
        {
            var wordCounts = new Dictionary<string, int>();
            var words = Regex.Split(text.ToLower(), @"\W+");

            foreach (var word in words)
            {
                if (string.IsNullOrWhiteSpace(word)) continue;

                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            return wordCounts;
        }
    }
}
