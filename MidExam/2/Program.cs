using System;
using System.Collections.Generic;
using System.Linq;

namespace _2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list= Console.ReadLine().Split("||").ToList();
            
            int fuel = int.Parse(Console.ReadLine());
            int immunition = int.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                List<string> lineAndNumber = list[i].Split(' ').ToList();
                switch (lineAndNumber[0])
                {
                    case "Travel":
                        Console.WriteLine(Travel(lineAndNumber, fuel)); 
                        if (Travel(lineAndNumber, fuel) == "Mission failed.")
                        {
                            return;
                        }
                        else
                        {
                            fuel = fuel - int.Parse(lineAndNumber[1]);
                        }
                        break;
                    case "Enemy":
                        Console.WriteLine(Enemy(lineAndNumber, immunition, fuel));
                        if (Enemy(lineAndNumber, immunition, fuel) == "Mission failed.")
                        {
                            return;
                        }
                        if (Enemy(lineAndNumber, immunition, fuel) == $"An enemy with {lineAndNumber[1]} armour is defeated.")
                        {
                            immunition = immunition - int.Parse(lineAndNumber[1]);
                        }
                        else
                        {
                            fuel = fuel - int.Parse(lineAndNumber[1]) * 2;
                        }
                        break;
                    case "Repair":
                        Repair(lineAndNumber);
                        immunition= immunition+int.Parse(lineAndNumber[1]) * 2;
                        fuel = fuel + int.Parse(lineAndNumber[1]);
                        break;
                    case "Titan":
                        Console.WriteLine("You have reached Titan, all passengers are safe.");
                        return;
                       
                }


            }

        }
        static string Travel(List<string>list,int fuel)
        {
           
            if (fuel - int.Parse(list[1])<0)
            {
                return "Mission failed.";
                
            }
            else
            {
                return $"The spaceship travelled {list[1]} light-years.";
            }

        }
        static string Enemy (List<string> list, int immunition, int fuel)
        {

            if (immunition - int.Parse(list[1]) >= 0)
            {
                return $"An enemy with {list[1]} armour is defeated.";
            }
            else
            {
                if (fuel - int.Parse(list[1]) * 2 >= 0)
                {
                    return $"An enemy with {list[1]} armour is outmaneuvered.";
                    
                }
                else
                {
                    return "Mission failed.";
                }
                
                
            }

        }
        static void Repair(List<string> list)
        {
            Console.WriteLine($"Ammunitions added: {int.Parse(list[1])*2}.");
            Console.WriteLine($"Fuel added: {int.Parse(list[1])}.");

        }
    }
}
