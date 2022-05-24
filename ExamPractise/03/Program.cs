using System;
using System.Collections.Generic;

namespace _03
{
    internal class Program
    {
        class Heros
        {
           
            public int Hp { get; set; }
            public int MP { get; set; }
            public Heros( int hp , int mp)
            {
               
                this.Hp = hp;
                this.MP = mp;
            }
        }
        static void Main(string[] args)
        {
           int numberOfHeros = int.Parse(Console.ReadLine());
            Dictionary<string,Heros> heros = new Dictionary<string,Heros>();
            for (int i = 1; i <= numberOfHeros; i++)
            {
                string[] line = Console.ReadLine().Split(' ');
                heros.Add(line[0], new Heros(int.Parse(line[1]), int.Parse(line[2])));
               
            }
            string commandLine = Console.ReadLine();
            while (commandLine != "End")
            {
                string[] command = commandLine.Split(" - ");
                switch (command[0])
                {
                    case "CastSpell":
                        if (heros[command[1]].MP>=int.Parse(command[2]))
                        {
                            heros[command[1]].MP = heros[command[1]].MP - int.Parse(command[2]);
                            Console.WriteLine($"{command[1]} has successfully cast {command[3]} and now has {heros[command[1]].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} does not have enough MP to cast {command[3]}!");
                        }
                        break;
                    case "TakeDamage":
                        if (heros[command[1]].Hp > int.Parse(command[2]))
                        {
                            heros[command[1]].Hp = heros[command[1]].Hp- int.Parse(command[2]);
                            Console.WriteLine($"{command[1]} was hit for {command[2]} HP by {command[3]} and now has {heros[command[1]].Hp} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{command[1]} has been killed by {command[3]}!");
                            heros.Remove(command[1]);
                        }
                        break;
                    case "Recharge":
                        int amountMP = heros[command[1]].MP;
                        heros[command[1]].MP += int.Parse(command[2]);
                        if (heros[command[1]].MP>200)
                        {
                            heros[command[1]].MP = 200;
                        }
                        Console.WriteLine($"{command[1]} recharged for {heros[command[1]].MP - amountMP} MP!");
                        break;
                    case "Heal":
                        int amountHeal = heros[command[1]].Hp;
                        heros[command[1]].Hp+= int.Parse(command[2]); 
                        if (heros[command[1]].Hp > 100)
                        {
                            heros[command[1]].Hp = 100;
                           
                        }
                        Console.WriteLine($"{command[1]} healed for {heros[command[1]].Hp - amountHeal} HP!");
                        break;
                }
                commandLine = Console.ReadLine();
            }
            foreach(var hero in heros)
            {
                Console.WriteLine($"{hero.Key}");
                Console.WriteLine($" HP: {hero.Value.Hp}");
                Console.WriteLine($" MP: {hero.Value.MP}");
            }
        }
    }
}
