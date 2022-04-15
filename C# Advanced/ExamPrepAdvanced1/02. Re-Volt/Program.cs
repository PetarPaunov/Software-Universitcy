using System;

namespace _02._Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int fieldCords = int.Parse(Console.ReadLine());
            int commandsCount = int.Parse(Console.ReadLine());

            char[,] matrixField = new char[fieldCords, fieldCords];
            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
                char[] fieldInput = Console.ReadLine().ToCharArray();
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    matrixField[row, col] = fieldInput[col];
                    if (matrixField[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            bool win = false;
            for (int i = 0; i < commandsCount; i++)
            {
                string command = Console.ReadLine();

                if (command == "down")
                {
                    matrixField[playerRow, playerCol] = '-';
                    playerRow++;
                    if (playerRow >= matrixField.GetLength(0))
                    {
                        playerRow = 0;
                    }
                    if (matrixField[playerRow, playerCol] == 'B')
                    {
                        playerRow++;
                        if (playerRow >= matrixField.GetLength(0))
                        {
                            playerRow = 0;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'T')
                    {
                        playerRow--;
                        if (playerRow >= matrixField.GetLength(0))
                        {
                            playerRow = 0;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        matrixField[playerRow, playerCol] = 'f';
                        win = true;
                        break;
                    }
 
                    matrixField[playerRow, playerCol] = 'f';
                     
                }
                else if (command == "up")
                {
                    matrixField[playerRow, playerCol] = '-';
                    playerRow--;
                    if (playerRow < 0)
                    {
                        playerRow = matrixField.GetLength(0) - 1;
                    }
                    if (matrixField[playerRow, playerCol] == 'B')
                    {
                        playerRow--;
                        if (playerRow < 0)
                        {
                            playerRow = matrixField.GetLength(0) - 1;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'T')
                    {
                        playerRow++;
                        if (playerRow < 0)
                        {
                            playerRow = matrixField.GetLength(0) - 1;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        matrixField[playerRow, playerCol] = 'f';
                        win = true;
                        break;
                    }
 
                    matrixField[playerRow, playerCol] = 'f';

                }
                else if (command == "left")
                {
                    matrixField[playerRow, playerCol] = '-';
                    playerCol--;
                    if (playerCol < 0)
                    {
                        playerCol = matrixField.GetLength(1) - 1;
                    }
                    if (matrixField[playerRow, playerCol] == 'B')
                    {
                        playerCol--;
                        if (playerCol < 0)
                        {
                            playerCol = matrixField.GetLength(1) - 1;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'T')
                    {
                        playerCol++;
                        if (playerCol < 0)
                        {
                            playerCol = matrixField.GetLength(1) - 1;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        matrixField[playerRow, playerCol] = 'f';
                        win = true;
                        break;
                    }
                     
                    matrixField[playerRow, playerCol] = 'f';

                }
                else if (command == "right")
                {
                    matrixField[playerRow, playerCol] = '-';
                    playerCol++;
                    if (playerCol >= matrixField.GetLength(1))
                    {
                        playerCol = 0;
                    }
                    if (matrixField[playerRow, playerCol] == 'B')
                    {
                        playerCol++;
                        if (playerCol >= matrixField.GetLength(1))
                        {
                            playerCol = 0;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'T')
                    {
                        playerCol--;
                        if (playerCol >= matrixField.GetLength(1))
                        {
                            playerCol = 0;
                        }
                    }
                    if (matrixField[playerRow, playerCol] == 'F')
                    {
                        Console.WriteLine("Player won!");
                        matrixField[playerRow, playerCol] = 'f';
                        win = true;
                        break;
                    }
                     
                    matrixField[playerRow, playerCol] = 'f';
                }
                 
            }

            if (!win)
            {
                Console.WriteLine("Player lost!");
            }


            for (int row = 0; row < matrixField.GetLength(0); row++)
            {
              
                for (int col = 0; col < matrixField.GetLength(1); col++)
                {
                    Console.Write(matrixField[row, col]);  
                }
                Console.WriteLine();
            }
        }
    }
}
