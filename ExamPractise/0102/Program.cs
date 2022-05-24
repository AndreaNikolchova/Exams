using System;
using System.Text;
using System.Linq;

namespace _0102
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imputStops = Console.ReadLine();
            StringBuilder stops = new StringBuilder();
            stops.Append(imputStops);
            string imput  = Console.ReadLine();
            while (imput!= "Travel")
            {
                string[] command = imput.Split(':');
                switch (command[0])
                {
                    case "Add Stop":
                        if (int.Parse(command[1])>= 0&&int.Parse(command[1])<=stops.Length-1)
                        {
                              stops.Insert(int.Parse(command[1]),command[2]);
                        }
                        Console.WriteLine(stops.ToString());
                        break;
                    case "Remove Stop":
                        if (int.Parse(command[1]) >= 0 && int.Parse(command[1]) <= stops.Length-1&& int.Parse(command[2]) >= 0 && int.Parse(command[2]) <= stops.Length-1)
                        {
                            int leght = int.Parse(command[2]) - int.Parse(command[1]);
                            stops.Remove(int.Parse(command[1]),leght+1);
                        }
                        Console.WriteLine(stops.ToString());
                        break;
                    case "Switch":
                        stops.Replace(command[1], command[2]);
                        Console.WriteLine(stops.ToString());
                        break;
                }
                imput = Console.ReadLine();

            }
            Console.WriteLine($"Ready for world tour! Planned stops: {stops.ToString()}");

        }
    }
}
