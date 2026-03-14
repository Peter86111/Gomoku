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
            Console.Write(prompt);
            string line = Console.ReadLine().ToUpper();

            if (line.Length == 1 && line[0] >= 'A' && line[0] <= 'O')
            {
                return line[0] - 'A';
            }

            else
            {
                return -1;
            }
        }

        public int ReadInt(string prompt)
        {
            const int min = 0;
            const int max = 14;

            Console.Write(prompt);
            string line = Console.ReadLine();

            if (int.TryParse(line, out int number) && number >= min && number <= max)
            {
                return number;
            }

            else
            {
                return -1;
            }
        }
        
        public int ReadIntForMenu(string prompt)
        {
            const int min = 1;
            const int max = 3;

            Console.Write(prompt);
            string line = Console.ReadLine();

            if (int.TryParse(line, out int number) && number >= min && number <= max)
            {
                return number;
            }

            else
            {
                return -1;
            }
        }
    }
}
