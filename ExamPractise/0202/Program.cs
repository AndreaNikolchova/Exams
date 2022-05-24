using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _0202
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([=]|[\/])([A-Z][A-Za-z]{2,})([=]|[\/])";
            string imput = Console.ReadLine();
            MatchCollection match = Regex.Matches(imput, pattern);
            List<string> result = new List<string>();
            int sum = 0;
            foreach (Match m in match)
            {
                if (m.Groups[1].Value == m.Groups[3].Value)
                {
                    result.Add(m.Groups[2].Value);
                    sum += m.Groups[2].Value.Length;
                }
            }
            Console.WriteLine($"Destinations: {string.Join(", ",result)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
