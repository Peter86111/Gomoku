using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Input
{
    internal class ConsoleInput
    {
        public int ReadString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine().ToUpper();

                if (line.Length == 1 && line[0] >= 'A' && line[0] <= 'O')
                {
                    return line[0] - 'A';
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Try again between 'A' and 'O'.");
                    Console.ResetColor();
                }
            }
        }

        public int ReadInt(string prompt)
        {
            const int min = 0;
            const int max = 14;

            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();

                if (int.TryParse(line, out int number) && number >= min && number <= max)
                {
                    return number;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Try again between 0 and 14.");
                    Console.ResetColor();
                }
            }
        }        
    }
}
