using System;
using System.Collections.Generic;
using System.Linq;

namespace Tiles_Master
{
    internal class Program
    {
        public static Stack<int> FillStack(int[] stackLine)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < stackLine.Length; i++)
                stack.Push(stackLine[i]);
            return stack;
        }
        public static Queue<int> FillQueue(int[] queueLine)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < queueLine.Length; i++)
                queue.Enqueue(queueLine[i]);
            return queue;

        }
        static void Main(string[] args)
        {
            int[] stackLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] queueLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Stack<int> whiteTiles = FillStack(stackLine);
            Queue<int> greyTiles = FillQueue(queueLine);

            Dictionary<string, int> plase = new Dictionary<string, int>()
            {
                {"Sink",0},
                {"Oven",0},
                {"Countertop",0},
                {"Wall",0},
                {"Floor",0}
            };


            while (whiteTiles.Count > 0 && greyTiles.Count > 0)
            {
                int currentWhite = whiteTiles.Peek();
                int currentGrey = greyTiles.Peek();
                if (currentWhite == currentGrey)
                {
                    int sum = currentWhite + currentGrey;
                    switch (sum)
                    {
                        case 40:
                            plase["Sink"]++;
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                            break;
                        case 50:
                            plase["Oven"]++;
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                            break;
                        case 60:
                            plase["Countertop"]++;
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                            break;
                        case 70:
                            plase["Wall"]++;
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                            break;
                        default:
                            plase["Floor"]++;
                            whiteTiles.Pop();
                            greyTiles.Dequeue();
                            break;
                    }
                }
                else
                {
                    currentWhite = currentWhite / 2;
                    whiteTiles.Pop();
                    whiteTiles.Push(currentWhite);
                    greyTiles.Dequeue();
                    greyTiles.Enqueue(currentGrey);
                }
            }
            if (whiteTiles.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTiles)}");
            }
            if (greyTiles.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTiles)}");
            }
            var list = plase.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToList();
            foreach (var item in list)
            {
                if (item.Value != 0)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
