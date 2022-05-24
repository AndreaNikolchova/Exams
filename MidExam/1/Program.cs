using System;

namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cyties = int.Parse(Console.ReadLine());
            decimal sum = 0;
            for (int i = 1; i <= cyties; i++)
            {
                string nameOfTheCity = Console.ReadLine();
                decimal moneyEarned = decimal.Parse(Console.ReadLine());
                decimal moneyHeNeedsToSpend = decimal.Parse(Console.ReadLine());
                if (i % 3 == 0 && i % 5 == 0)
                {
                    moneyEarned = moneyEarned * 0.9m;
                }
                else if (i % 3 == 0)
                {
                    moneyHeNeedsToSpend =moneyHeNeedsToSpend+ moneyHeNeedsToSpend * 0.5m;

                }
                else if (i % 5 == 0)
                {
                    moneyEarned = moneyEarned * 0.9m;
                }
                sum += moneyEarned - moneyHeNeedsToSpend;
                moneyEarned -= moneyHeNeedsToSpend;
                Console.WriteLine($"In {nameOfTheCity} Burger Bus earned {moneyEarned:f2} leva.");
            }
            Console.WriteLine($"Burger Bus total profit: {sum:f2} leva.");
        }
    }
}
