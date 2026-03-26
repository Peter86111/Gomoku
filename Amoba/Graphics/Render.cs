using Gomoku.Core;
using Gomoku.Interface;
using Gomoku.Menu;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Graphics
{
    internal class Render: IRender
    {        
        public void Board(CellState[,] cellStates)
        {
            // Enable UTF-8 encoding to properly display box-drawing and Unicode characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Get current console width to calculate horizontal centering
            int consoleWidth = Console.WindowWidth;

            // Logical width of the board (used for centering)
            int columnWidth = 55;
            int rowWidth = 55;

            // Horizontal and vertical padding to center the board
            int paddingX = (consoleWidth - columnWidth) / 2;
            int paddingY = (consoleWidth - rowWidth) / 2;

            Console.WriteLine();

            // Horizontal axis (X-axis) charachters
            // Represents column indices from A to O
            string axisX = "      A  B  C  D  E  F  G  H  I  J  K  L  M  N  O\n";
            
            // Print X-axis centered horizontally
            foreach (string line in axisX.Split('\n'))
            {
                Console.WriteLine(new string(' ', paddingX) + line);
            }

            // Iterate through rows (Y-axis)
            for (int y = 0; y < cellStates.GetLength(0); y++)
            {
                // Y-axis numbering with left border (│)
                string axisY = $"{y,2}  " + "\u2502";
                
                // Print Y-axis with horizontal padding
                foreach (string line in axisY.Split('\n'))
                {                    
                    Console.Write(new string(' ', paddingY) + line);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                }                

                // Iterate through columns (X-axis)
                for (int x = 0; x < cellStates.GetLength(1); x++)
                {
                    // Draw cell content based on its state
                    switch (cellStates[x, y])
                    {
                        case CellState.Empty:
                            // Empty field with grid intersection
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("\u2500\u253c\u2500");    // ─┼─
                            break;

                        case CellState.Black:
                            // Black stone
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write(" \u2b24 ");
                            break;

                        case CellState.White:
                            // White stone                            
                            Console.Write(" \x1b[30m\x1b[37m\u25cf\x1b[30m ");    // Use ANSI escape code for black line - white stone - black line
                            break;
                    }
                }
                // Reset colors and close the row with a right border (│)
                Console.ResetColor();
                Console.Write("\u2502");
                Console.WriteLine();
            }

            Console.ResetColor();
        }

        public void GetTitle()
        {
            // Get console width to calculate horizontal centering
            int consoleWidth = Console.WindowWidth;            

            // ASCII art title for the game
            string gomokuLogo = @"
                 ██████╗  ██████╗ ███╗   ███╗ ██████╗ ██╗  ██╗ ██╗   ██╗
                ██╔════╝ ██╔═══██╗████╗ ████║██╔═══██╗██║ ██╔╝ ██║   ██║
                ██║  ███╗██║   ██║██╔████╔██║██║   ██║█████╔╝  ██║   ██║
                ██║   ██║██║   ██║██║╚██╔╝██║██║   ██║██╔═██╗  ██║   ██║
                ╚██████╔╝╚██████╔╝██║ ╚═╝ ██║╚██████╔╝██║  ██╗ ╚██████╔╝
                 ╚═════╝  ╚═════╝ ╚═╝     ╚═╝ ╚═════╝ ╚═╝  ╚═╝  ╚═════╝ 

                ========================================================

                       G O M O K U   –   F I V E   I N   A   R O W

                ========================================================

                          Black starts. Think ahead. Win smart.
                ";

            // Clear console before rendering the title
            Console.Clear();
            Console.WriteLine();

            // Print the logo line by line with horizontal centering
            foreach (string line in gomokuLogo.Split('\n'))
            {
                var clearLine = line.Trim();

                // Fixed width of the ASCII logo
                int logoWidth = clearLine.Length;

                // Calculate padding to center the logo
                int padding = (consoleWidth - logoWidth) / 2;

                Console.WriteLine(new string(' ', padding) + clearLine);
            }            
        }  
        
        public void GetMenu()
        {
            int consoleWidth = Console.WindowWidth;          

            string menu = @"(1) Run game 
                            (2) Game rule 
                            (3) Exit";

            foreach (string line in menu.Split('\n'))
            {               
                int menuWordWidth = 14;                
                int padding = (consoleWidth - menuWordWidth) / 2;
                
                var cleanLine = line.Trim();

                Console.WriteLine(new string(' ', padding) + cleanLine);
            }
        }

        public void CenterRuleInfoText(GameInfo gameInfo)
        {
            var word = gameInfo.GameRuleInfo().Split('\n');

            int consoleWidth = Console.WindowWidth;

            foreach (string line in word)
            {
                var cleanLine = line.Trim();

                int ruleWidth = cleanLine.Length;
                int padding = (consoleWidth - ruleWidth) / 2;                

                Console.WriteLine(new string(' ', padding) + cleanLine);
            }
        }
        
        public string CenterText(string prompt)
        {
            int consoleWidth = Console.WindowWidth;
            int promptWidth = prompt.Length;
            int padding = (consoleWidth - promptWidth) / 2;

            if (padding < 0)
            {
                padding = 0;
            }

            Console.WriteLine();

            return new string(' ', padding) + prompt;
        }
        
        public string CenterWarningText(string prompt)
        {
            int consoleWidth = Console.WindowWidth;
            int promptWidth = prompt.Length;
            int padding = (consoleWidth - promptWidth) / 2;

            if (padding < 0)
            {
                padding = 0;
            }

            Console.WriteLine();

            return new string(' ', padding) + "\x1b[91m" + prompt + "\x1b[0m";  // Use ASCII code for red color
        }

        public string CenterWinnerText(string prompt)
        {
            int consoleWidth = Console.WindowWidth;
            int promptWidth = prompt.Length;
            int padding = (consoleWidth - promptWidth) / 2;

            if (padding < 0)
            {
                padding = 0;
            }

            Console.WriteLine();

            return new string(' ', padding) + "\u001b[30;43m" + prompt + "\u001b[0m";
        }
    }
}