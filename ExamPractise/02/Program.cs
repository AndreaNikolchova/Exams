using System;
using System.Text.RegularExpressions;

namespace _02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"[@][#]+([A-Z][A-Za-z0-9]{4,}[A-Z])[@][#]+";
            int numberOfBarcodes = int.Parse(Console.ReadLine());
            for (int i = 1; i <= numberOfBarcodes; i++)
            {
                Match match = Regex.Match(Console.ReadLine(), pattern);
                if (match.Success)
                {
                    char[] number =  match.Groups[1].ToString().ToCharArray();
                    string code = string.Empty;
                 
                   foreach(char c in number)
                    {
                        if (Char.IsDigit(c))
                        {
                            code += c;
                        }
                    }
                    if (code==string.Empty)
                    {
                        Console.WriteLine($"Product group: 00");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {code}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid barcode");
                }
            }
        }
    }
}
