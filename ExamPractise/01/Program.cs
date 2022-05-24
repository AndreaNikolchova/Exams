using System;
using System.Collections.Generic;
using System.Text;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string imput  = Console.ReadLine();
            char[] passwordImput = imput.ToCharArray();
            string line = Console.ReadLine();
            StringBuilder password = new StringBuilder();
            password.Append(passwordImput);
            StringBuilder sbHelp = new StringBuilder();
            while (line!="Done")
            {
                string[] command = line.Split(' ',StringSplitOptions.RemoveEmptyEntries);
                switch (command[0])
                {
                    case "TakeOdd":
                        for (int i = 1; i <password.Length ; i+=2)
                        {
                            sbHelp.Append(password[i]);
                        }
                        password.Clear();
                        password.Append(sbHelp.ToString());
                        Console.WriteLine(password.ToString());
                        break;
                    case "Cut":
                        password.Remove(int.Parse(command[1]), int.Parse(command[2]));
                        Console.WriteLine(password.ToString());
                        break;
                    case "Substitute":
                        string oldPasword = password.ToString();
                        password.Replace(command[1], command[2]);
                        if (oldPasword!=password.ToString())
                        {
                            Console.WriteLine(password.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                        }
                        break;
                    
                }
                line = Console.ReadLine();  
            }
            Console.WriteLine($"Your password is: {password.ToString()}");
        }
    }
}
