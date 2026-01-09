using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Input
{
    internal class ConsoleInput
    {
        #region Methods
        public int ReadInt(string prompt)
        {
            int min = 0;
            int max = 14;

            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();

                if (int.TryParse(line, out int number) && number >= min && number <= max)
                {
                    return number;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input! Try again between 0 and 14.");
                Console.ResetColor();
            }
        }
        #endregion
    }
}
