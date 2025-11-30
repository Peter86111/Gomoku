using System.Collections.Specialized;
using System.Net;

namespace Gomoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var field = Board(BoardSize(10));

            bool gameOver = false;

            #region Game
            while (!gameOver)
            {
                //Console.Clear();
                
                string[] title = { "   \u2554\u2550\u2550 G O M O K U \u2550\u2550\u2557" };

                foreach (var t in title)
                {
                    Console.WriteLine(t);
                }

                PrintBoard(field);
                
                var player = GetPlayer(ReadInt("\nChoose mark:\n1: X, 2: O - ", 1, 2));

                var (y, x) = MakeMove(player);
                
                //Console.Clear();
                //PrintBoard(field);

                if (CheckWinHorizontally(field, player, y, x) || CheckWinVertically(field, player, y, x) || CheckWinMainDiagonally(field, player, y, x) || CheckWinAntiDiagonal(field, player, y, x))
                {
                    Console.WriteLine($"Winner: {(player == 1 ? "X" : "O")}");
                    break;
                }                
            }


            #endregion



            #region Methods
            // Board size
            int[,] BoardSize(int size)
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
            (int lastY, int lastX) MakeMove(int player)
            {
                int lastX = ReadInt("Enter the column number between 0 and 9: ", 0, 9);
                int lastY = ReadInt("Enter the row number between 0 and 9: ", 0, 9);

                if (field[lastY, lastX] == 0)
                {
                    field[lastY, lastX] = player;
                }

                else
                {
                    Console.WriteLine("The field is not empty!");
                }

                return (lastY, lastX);
            }

            // Check for horizontal winning lines from the last player's position
            bool CheckWinHorizontally(int[,] field, int player, int y, int x)
            {                
                int countLeft = 0;
                int countRight = 0;
                
                for (int i = x + 1; i < field.GetLength(1); i++)    // check continous marks to the right of the starting position
                {
                    if (field[y, i] == player)
                    {
                        countRight++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }

                for (int i = x - 1; i >= 0; i--)    // check continous marks to the left of the starting position
                {
                    if (field[y, i] == player)
                    {
                        countLeft++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }

                int sum = countLeft + 1 + countRight;   // total continous marks inclulding the starting one

                if (sum == 5)
                {
                    gameOver = true;
                    return true;
                }

                return false;
            }

            // Check for vertical winning lines from the last player's position
            bool CheckWinVertically(int[,] field, int player, int y, int x)
            {
                int countBottom = 0;
                int countTop = 0;
                
                for (int i = y + 1; i < field.GetLength(0); i++)    // check continous marks to the bottom of the starting position
                {
                    if (field[i, x] == player)
                    {
                        countBottom++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }

                for (int i = y - 1; i >= 0; i--)    // check continous marks to the top of the starting position
                {
                    if (field[i, x] == player)
                    {
                        countTop++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }

                int sum = countBottom + 1 + countTop;   // Total continous marks inclulding the starting one

                if (sum == 5)
                {
                    gameOver = true;
                    return true;
                }

                return false;
            }

            // Check for main diagonal (right, bottom - left, top) winning lines from the last player's position
            bool CheckWinMainDiagonally(int[,] field, int player, int y, int x)
            {
                int countPrev = 0;
                int countNext = 0;

                int nextX = x + 1;
                int nextY = y + 1;

                int prevX = x - 1;
                int prevY = y - 1;

                for (; nextX < field.GetLength(1) && nextY < field.GetLength(0); nextX++, nextY++)  // check continous marks to the right, bottom of the starting position
                {
                    if (field[nextY, nextX] == player)
                    {
                        countNext++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }                    
                }

                for (; prevX >= 0 && prevY >= 0; prevX--, prevY--)  // check continous marks to the left, top of the starting position
                {
                    if (field[prevY, prevX] == player)
                    {
                        countPrev++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }

                int sum = countPrev + 1 + countNext;    // Total continous marks inclulding the starting one

                if (sum == 5)
                {
                    gameOver = true;
                    return true;
                }

                return false;
            }

            // Check for right diagonal (right, top - left, bottom) winning lines from the last player's position
            bool CheckWinAntiDiagonal(int[,] field, int player, int y, int x)
            {
                int countTop = 0;
                int countBottom = 0;

                int nextTopX = x + 1;
                int nextTopY = y - 1;

                int nextBottomX = x - 1;
                int nextBottomY = y + 1;

                for (; nextTopX < field.GetLength(1) && nextTopY >= 0; nextTopX++, nextTopY--)    // check continous marks to the right, top of the starting position
                {
                    if (field[nextTopY, nextTopX] == player)
                    {
                        countTop++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }                

                for (; nextBottomX >= 0 && nextBottomY < field.GetLength(0); nextBottomX--, nextBottomY++)    // check continous marks to the left, bottom of the starting position
                {
                    if (field[nextBottomY, nextBottomX] == player)
                    {
                        countBottom++;
                    }

                    else
                    {
                        break;  // if not player, stop the count
                    }
                }

                int sum = countTop + 1 + countBottom;   // Total continous marks inclulding the starting one

                if (sum == 5)
                {
                    gameOver = true;
                    return true;
                }

                return false;
            }


        }


        #endregion    
    }
}
