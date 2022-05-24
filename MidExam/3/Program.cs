using System;
using System.Collections.Generic;
using System.Linq;

namespace _3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<string> cards = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToList();
            int lenght = int.Parse(Console.ReadLine());
            for (int i = 1; i <= lenght; i++)
            {
                List<string> line = Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToList();
                switch (line[0])
                {

                    case "Add":
                        Add(cards, line);
                        break;
                    case "Remove":
                        Remove(cards, line);
                        break;
                    case "Remove At":
                        RemoveAt(cards, line);
                        break;
                    case "Insert":
                        Insert(cards, line);
                        break;
                }

            }
            Console.Write(String.Join(", ",cards));
        }
        static void Add (List<string> cards , List<string> line)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (line[1] == cards[i])
                {
                    Console.WriteLine("Card is already in the deck");
                    return;
                }
            }
            cards.Add(line[1]);
            Console.WriteLine("Card successfully added");
        }
        static void Remove(List<string> cards, List<string> line)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i]==line[1])
                {
                    Console.WriteLine("Card successfully removed");
                    cards.Remove(cards[i]);
                    return;
                }
            }
            Console.WriteLine("Card not found");

        }
        static void RemoveAt(List<string> cards, List<string> line)
        {
            if (int.Parse(line[1]) > cards.Count-1 || int.Parse(line[1])<0)
            {
                Console.WriteLine("Index out of range");
                return;
            }
            cards.RemoveAt(int.Parse(line[1]));
            Console.WriteLine("Card successfully removed");
        }
        static void Insert(List<string> cards, List<string> line)
        {
            if ( int.Parse(line[1])>cards.Count-1 || int.Parse(line[1]) < 0)
            {
                Console.WriteLine("Index out of range");
                return;
            }
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i] == line[2])
                {
                    Console.WriteLine("Card is already added");
                    return;
                }
            }
            cards.Insert(int.Parse(line[1]),line[2]);
            Console.WriteLine("Card successfully added");
        }
    }
}
