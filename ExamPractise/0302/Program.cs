using System;
using System.Collections.Generic;

namespace _0302
{
    internal class Program
    {
        class Plant
        {
            public double Rarity { get; set; }
            public double Rating { get; set;}
            public int Count { get; set; }
            public Plant(double rating)
            {
                this.Rating = 0;
                this.Count = 0;
                this.Rarity = rating;
            }
        }
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();
            for (int i = 0; i < number; i++)
            {
                string[] line = Console.ReadLine().Split("<->", StringSplitOptions.RemoveEmptyEntries);
                if (plants.ContainsKey(line[0]))
                {
                    plants[line[0]] = new Plant(double.Parse(line[1]));
                }
                else
                {
                    plants.Add(line[0], new Plant(double.Parse(line[1])));
                }
            }
            string commandLine = Console.ReadLine();
            while (commandLine != "Exhibition")
            {
                string[] command = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {

                    case "Rate:":
                        if (!plants.ContainsKey(command[1]))
                        {
                            Console.WriteLine("error");
                        }
                        else
                        {
                            plants[command[1]].Rating+= double.Parse(command[3]);
                            plants[command[1]].Count++;
                        }
                        break;
                    case "Update:":
                        if (!plants.ContainsKey(command[1]))
                        {
                            Console.WriteLine("error");
                        }
                        else
                        {
                            plants[command[1]].Rarity = double.Parse(command[3]);
                        }
                        break;
                    case "Reset:":
                        if (!plants.ContainsKey(command[1]))
                        {
                            Console.WriteLine("error");
                        }
                        else
                        {
                            plants[command[1]].Rating = 0;
                            plants[command[1]].Count = 0;
                        }
                        break;

                }
                commandLine = Console.ReadLine();
            }
            
            Console.WriteLine("Plants for the exhibition:");
            foreach (var plant in plants)
            {
                if (plant.Value.Count == 0)
                {
                    Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {0:f2}");
                }
                else
                {
                Console.WriteLine($"- {plant.Key}; Rarity: {plant.Value.Rarity}; Rating: {plant.Value.Rating/ plant.Value.Count:f2}");

                }
            }
               
            
        }
    }
}
