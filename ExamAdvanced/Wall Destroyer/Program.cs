using System;

namespace Wall_Destroyer
{
    internal class Program
    {
        public static void FillingMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = line[j];
                }
            }
        }
        static void Main(string[] args)
        {
            int holes = 1;
            int rodes = 0;
            int n  = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            FillingMatrix(matrix);
            while (true)
            {
                string command = Console.ReadLine();
                if (command=="End")
                {
                    Console.WriteLine($"Vanko managed to make {holes} hole(s) and he hit only {rodes} rod(s).");
                    Print(matrix);
                    return;
                }
                switch(command)
                {
                    case "up":
                       string answer = Up(matrix,holes,rodes);
                        if (answer.StartsWith("Vanko"))
                        {
                            Console.WriteLine(answer);
                            Print(matrix);
                            return;
                        }
                        else if (answer.StartsWith("R"))
                        {
                            string[] rodesAnswer = answer.Split(' ');
                            rodes = int.Parse(rodesAnswer[1]);
                        }
                        else if(!answer.StartsWith(" "))
                        {
                            holes = int.Parse(answer);
                        }
                        break;
                    case "down":
                        answer = Down(matrix, holes, rodes);
                        if (answer.StartsWith("Vanko"))
                        {
                            Console.WriteLine(answer);
                            Print(matrix);
                            return;
                        }
                        else if (answer.StartsWith("R"))
                        {
                            string[] rodesAnswer = answer.Split(' ');
                            rodes = int.Parse(rodesAnswer[1]);
                        }
                        else if(!answer.StartsWith(" "))
                        {
                            holes = int.Parse(answer);
                        }
                        break;
                    case "left":
                        answer = Left(matrix, holes, rodes);
                        if (answer.StartsWith("Vanko"))
                        {
                            Console.WriteLine(answer);
                            Print(matrix);
                            return;
                        }
                        else if (answer.StartsWith("R"))
                        {
                            string[] rodesAnswer = answer.Split(' ');
                            rodes = int.Parse(rodesAnswer[1]);
                        }
                        else if (!answer.StartsWith(" "))
                        {
                            holes = int.Parse(answer);
                        }
                        break;
                    case "right":
                        answer = Right(matrix, holes, rodes);
                        if (answer.StartsWith("Vanko"))
                        {
                            Console.WriteLine(answer);
                            Print(matrix);
                            return;
                        }
                        else if (answer.StartsWith("R"))
                        {
                            string[] rodesAnswer = answer.Split(' ');
                            rodes = int.Parse(rodesAnswer[1]);
                        }
                        else if (!answer.StartsWith(" "))
                        {
                            holes = int.Parse(answer);
                        }
                        break;
                }
            }

        }

        private static void Print(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }

        public static string Right(char[,] matrix, int holes, int rodes)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        if (i >= 0 && i < matrix.GetLength(0) && j + 1 >= 0 && j + 1 < matrix.GetLength(1))
                        {
                            if (matrix[i, j + 1] == 'C')
                            {
                                holes++;
                                matrix[i, j + 1] = 'E';
                                matrix[i, j] = '*';
                                return $"Vanko got electrocuted, but he managed to make {holes} hole(s).";
                            }
                            else if (matrix[i, j + 1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodes++;
                                return "R" + " " + rodes.ToString();
                            }
                            else if (matrix[i,j+1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{i}, {j+1}]!");
                                matrix[i, j + 1] = 'V';
                                matrix[i, j] = '*';
                                return " ";
                            }
                            else 
                            {
                                holes++;
                                matrix[i, j] = '*';
                                matrix[i, j +1] = 'V';
                                return holes.ToString();
                            }
                        }
                    }
                }
            }
            return " ";
        }

        public static string Left(char[,] matrix, int holes, int rodes)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        if (i  >= 0 && i < matrix.GetLength(0) && j -1 >= 0 && j-1 < matrix.GetLength(1))
                        {
                            if (matrix[i, j-1] == 'C')
                            {
                                holes++;
                                matrix[i, j - 1] = 'E';
                                matrix[i, j] = '*';
                                return $"Vanko got electrocuted, but he managed to make {holes} hole(s).";
                            }
                             else if (matrix[i, j-1] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodes++;
                                return "R" + " " + rodes.ToString();
                            }
                            else if (matrix[i , j-1] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{i}, {j-1}]!");
                                matrix[i, j - 1] = 'V';
                                matrix[i, j] = '*';
                                return " ";
                            }
                            else
                            {
                                holes++;
                                matrix[i, j] = '*';
                                matrix[i, j-1] = 'V';
                                return holes.ToString();
                            }
                        }
                    }
                }
            }
            return " ";
        }

        public static string Down(char[,] matrix, int holes, int rodes)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 'V')
                    {
                        if (i + 1 >= 0 && i + 1 < matrix.GetLength(0) && j >= 0 && j < matrix.GetLength(1))
                        {
                            if (matrix[i + 1, j] == 'C')
                            {
                                holes++;
                                matrix[i + 1, j] = 'E';
                                matrix[i, j] = '*';
                                return $"Vanko got electrocuted, but he managed to make {holes} hole(s).";
                            }
                            else if (matrix[i + 1, j] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!");
                                rodes++;
                                return "R" + " " + rodes.ToString();
                            }
                            else if (matrix[i + 1, j] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{i + 1}, {j}]!"); 
                                matrix[i + 1, j] = 'V';
                                matrix[i, j] = '*';
                                return " ";
                            }
                            else
                            {
                                holes++;
                                matrix[i, j] = '*';
                                matrix[i + 1, j] = 'V';
                                return holes.ToString();
                            }
                        }
                    }
                }
            }
            return " ";
        }

        public static string Up(char[,] matrix, int holes, int rodes)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j]=='V')
                    {
                        if (i-1>=0&& i-1<matrix.GetLength(0)&& j>=0&&j<matrix.GetLength(1))
                        {
                            if (matrix[i - 1, j] == 'C')
                            {
                                holes++;
                                matrix[i - 1, j] = 'E';
                                matrix[i, j] = '*';
                                return $"Vanko got electrocuted, but he managed to make {holes} hole(s).";
                            }
                            else if (matrix[i - 1, j] == 'R')
                            {
                                Console.WriteLine("Vanko hit a rod!"); 
                                rodes++;
                                return "R" + " " +rodes.ToString();
                            }
                            else if (matrix[i - 1, j] == '*')
                            {
                                Console.WriteLine($"The wall is already destroyed at position [{i-1}, {j}]!");
                                matrix[i - 1, j] = 'V';
                                matrix[i, j] = '*';
                                return " ";
                            }
                            else
                            {
                                 holes++;
                                 matrix[i, j] = '*';
                                 matrix[i - 1, j] = 'V';
                                return holes.ToString();   
                            }
                        }
                    }
                }
            }
            return " ";
        }
    }
}
