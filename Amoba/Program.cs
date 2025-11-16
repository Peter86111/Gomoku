using System.Net;

namespace Gomoku
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            var field = Board(SizeBoard(10));

            bool gameOver = false;

            #region Game
            while (!gameOver)
            {
                Console.Clear();
                
                string[] title = { "   \u2554\u2550\u2550 G O M O K U \u2550\u2550\u2557" };
                foreach (var t in title)
                {
                    Console.WriteLine(t);
                }

                PrintBoard(field);
                
                var player = GetPlayer(ReadInt("\nChoose mark:\n1: X, 2: O - ", 1, 2));

                MakeMove(player);                

                if (CheckWin(field, player))
                {
                    if (player == 1)
                    {
                        Console.WriteLine("Winner: X");
                    }

                    else
                    {
                        Console.WriteLine("Winner: O");
                    }
                }                
            }
            #endregion


            #region Methods
            // Board size
            int[,] SizeBoard(int size)
            {
                return new int[size, size];
            }

            // Make the board
            int[,] Board(int[,] field)
            {                
                for (int y = 0; y < field.GetLength(0); y++)
                {
                    for (int x = 0; x < field.GetLength(1); x++)
                    {
                        field[y, x] = 0;
                    }
                }

                return field;
            }

            // Print the board
            int[,] PrintBoard(int[,] field)
            {
                Console.WriteLine();
                Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
                Console.WriteLine("    -------------------");

                for (int y = 0; y < field.GetLength(0); y++)
                {
                    Console.Write($"{y} | ");
                    for (int x = 0; x < field.GetLength(1); x++)
                    {
                        switch (field[y, x])
                        {
                            case 0:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.Write(". ");
                                break;

                            case 1:
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write("X ");
                                break;

                            case 2:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("O ");
                                break;
                        }          
                    }

                    Console.ResetColor();
                    Console.WriteLine();
                }

                Console.ResetColor();
                return field;
            }

            // Input for players
            int ReadInt(string prompt, int min, int max)
            {
                while (true)
                {
                    Console.Write(prompt);
                    string line = Console.ReadLine();

                    if (int.TryParse(line, out int number) && number >= min && number <= max)
                    {
                        return number;
                    }

                    Console.WriteLine($"Invalid input! Enter a number between {min} and {max}.");
                }
            }

            // Players
            int GetPlayer(int player)
            {
                if (player == 1)
                {
                    Console.WriteLine("Player: X");
                }

                else
                {
                    Console.WriteLine("Player: O");
                }

                return player;
            }

            // Player's move
            void MakeMove(int player)
            {
                int x = ReadInt("Enter the column number between 0 and 9: ", 0, 9);
                int y = ReadInt("Enter the row number between 0 and 9: ", 0, 9);

                if (field[y, x] == 0)
                {
                    field[y, x] = player;
                }

                else
                {
                    Console.WriteLine("The field is not empty!");
                }
            }

            // Check board state and count the number of 'X' and 'O'
            bool CheckWin(int[,] field, int player)
            {
                gameOver = true;

                int countX = 1;
                int countO = 1;

                //Console.WriteLine("\nInspect:");

                for (int y = 0; y < field.GetLength(0) - 1; y++)
                {                   
                    for (int x = 0; x < field.GetLength(1) - 1; x++)
                    {
                        // Check for winning lines horizontally, vertically, and diagonally
                        if (field[y, x] == player && field[y, x + 1] == player || field[y, x] == player && field[y + 1, x] == player || field[y, x] == player && field[y + 1, x + 1] == player) 
                        {
                            if (player == 1)
                            {
                                countX++;
                            }

                            else if (player == 2)
                            {
                                countO++;
                            }

                            else
                            {
                                countX = 1;
                                countO = 1;
                            }
                        }

                        //Console.Write(field[y, x] + " ");   // for inspect
                    }
                }
                //Console.WriteLine($"\nX: {countX}");    // for inspect
                //Console.WriteLine($"O: {countO}");  // for inspect

                if (countX == 5)
                {
                    return gameOver;
                }

                else if (countO == 5)
                {
                    return gameOver;
                }

                    return false;
            }
        }


        #endregion    
    }
}
