using System;
using System.Linq;

namespace ExamPrepAdvancedBeeProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeOfMatrix = int.Parse(Console.ReadLine());

            char[,] field = new char[sizeOfMatrix, sizeOfMatrix];

            int beeRow = 0;
            int beeCol = 0;

            for (int row = 0; row < field.GetLength(0); row++)
            {
                char[] rowLinec = Console.ReadLine().ToCharArray();
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = rowLinec[col];
                    if (field[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            int pollinate = 0;
            while (command != "End")
            {
                if (command == "up")
                {
                    field[beeRow, beeCol] = '.';
                    beeRow--;
                    if (beeRow < 0 || beeRow >= field.GetLength(0)
                        || beeCol < 0 || beeCol >= field.GetLength(1))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (field[beeRow, beeCol] == 'f')
                    {
                        field[beeRow, beeCol] = '.';
                        pollinate++;
                    }
                    if (field[beeRow, beeCol] == 'O')
                    {
                        field[beeRow, beeCol] = '.';
                        beeRow--;
                        if (field[beeRow, beeCol] == 'f')
                        {
                            pollinate++;
                        }
                    }
                }
                else if (command == "down")
                {
                    field[beeRow, beeCol] = '.';
                    beeRow++;
                    if (beeRow < 0 || beeRow >= field.GetLength(0)
                        || beeCol < 0 || beeCol >= field.GetLength(1))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (field[beeRow, beeCol] == 'f')
                    {
                        field[beeRow, beeCol] = '.';
                        pollinate++;
                    }
                    if (field[beeRow, beeCol] == 'O')
                    {
                        field[beeRow, beeCol] = '.';
                        beeRow++;
                        if (field[beeRow, beeCol] == 'f')
                        {
                            pollinate++;
                        }
                    }
                }
                else if (command == "left")
                {
                    field[beeRow, beeCol] = '.';
                    beeCol--;
                    if (beeRow < 0 || beeRow >= field.GetLength(0)
                        || beeCol < 0 || beeCol >= field.GetLength(1))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (field[beeRow, beeCol] == 'f')
                    {
                        field[beeRow, beeCol] = '.';
                        pollinate++;
                    }
                    if (field[beeRow, beeCol] == 'O')
                    {
                        field[beeRow, beeCol] = '.';
                        beeCol--;
                        if (field[beeRow, beeCol] == 'f')
                        {
                            pollinate++;
                        }
                    }
                }
                else if (command == "right")
                {
                    field[beeRow, beeCol] = '.';
                    beeCol++;
                    if (beeRow < 0 || beeRow >= field.GetLength(0)
                        || beeCol < 0 || beeCol >= field.GetLength(1))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (field[beeRow, beeCol] == 'f')
                    {
                        field[beeRow, beeCol] = '.';
                        pollinate++;
                    }
                    if (field[beeRow, beeCol] == 'O')
                    {
                        field[beeRow, beeCol] = '.';
                        beeCol++;
                        if (field[beeRow, beeCol] == 'f')
                        {
                            pollinate++;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            if (beeRow >= 0 && beeRow < field.GetLength(0)
                        && beeCol >= 0 && beeCol < field.GetLength(1))
            {
                field[beeRow, beeCol] = 'B';
            }
             

            if (pollinate < 5)
            {
                int needed = 5 - pollinate;
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {needed} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinate} flowers!");
            }


            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    Console.Write(field[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
