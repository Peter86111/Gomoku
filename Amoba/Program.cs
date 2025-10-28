namespace Amoba
{
    internal class Program
    {
        static void Main(string[] args)
        {          
            var field = Field(SizeField(10));

            //Random rnd = new Random();
            //RandomWall(field, 20, rnd);
            //PrintField(Player(field, 3, 6));

            //char currentPlayer = 'X';
            bool gameOver = false;

            while (!gameOver)
            {
                Console.Clear();
                
                Console.WriteLine("\nAmöba\n");

                PrintField(field);
                
                var player = GetPlayer(ReadInt("\n1: X, 2: O - ", 1, 2));

                
                Console.WriteLine($"\nA(z) {player} játékos következik!");

                // Az "X" kezd. Nyerésig felváltva írnak a pályára
                MakeMove(player);
                

                





            }







            #region Methods
            int[,] SizeField(int size)
            {
                return new int[size, size];
            }

            int[,] Field(int[,] field)
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

            int[,] PrintField(int[,] field)
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

            //int[,] RandomWall(int[,] field, int chance, Random rnd)
            //{
            //    for (int i = 0; i < field.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < field.GetLength(1); j++)
            //        {
            //            field[i, j] = rnd.Next(100) < chance ? 1 : 0;                        
            //        }
            //    }

            //    return field;
            //}

            //int[,] Player(int[,] field, int startX, int startY)
            //{
            //    if (field[startX, startY] == 1)
            //    {
            //        Console.WriteLine("A választott kezdőpozíció a falra esik!");
            //    }

            //    else
            //    {
            //        field[startX, startY] = 2;
            //    }

            //    return field;
            //}

            int ReadInt(string text, int min, int max)
            {
                while (true)
                {
                    Console.Write(text);
                    string line = Console.ReadLine();

                    if (int.TryParse(line, out int number) && number >= min && number <= max)
                    {
                        return number;
                    }

                    Console.WriteLine($"Hibás bevitel! Adj meg számot {min} és {max} között.");
                }
            }

            int GetPlayer(int player)
            {
                if (player == 1)
                {
                    Console.WriteLine("Játékos: X");
                }

                else
                {
                    Console.WriteLine("Játékos: O");
                }

                return player;
            }

            void MakeMove(int player)
            {
                int x = ReadInt("Add meg a oszlop számát 0-9 között: ", 0, 9);
                int y = ReadInt("Add meg az sor számát 0-9 között: ", 0, 9);

                if (field[y, x] == 0)
                {
                    field[y, x] = player;
                }

                else
                {
                    Console.WriteLine("A mező nem üres!");
                }
            }




            #endregion
        }
    }
}
