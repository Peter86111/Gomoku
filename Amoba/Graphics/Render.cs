using Gomoku.Core;
using Gomoku.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Graphics
{
    internal class Render: IRender
    {
        #region Methods
        public void Board(CellState[,] cellStates)
        {
            // Enable UTF-8 encoding to properly display box-drawing and Unicode characters
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Get current console width to calculate horizontal centering
            int consoleWidth = Console.WindowWidth;

            // Logical width of the board (used for centering)
            int columnWidth = 60;
            int rowWidth = 60;

            // Horizontal and vertical padding to center the board
            int paddingX = (consoleWidth - columnWidth) / 2;
            int paddingY = (consoleWidth - rowWidth) / 2;

            Console.WriteLine();

            // Horizontal axis (X-axis) numbering
            // Represents column indices from 0 to 14
            string axisX = "      0  1  2  3  4  5  6  7  8  9  10 11 12 13 14\n";  // x: column index (horizontal axis)

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
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(" \u25cf ");
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

            // Fixed width of the ASCII logo
            int logoWidth = 85;

            // Calculate padding to center the logo
            int padding = (consoleWidth - logoWidth) / 2;

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
                Console.WriteLine(new string(' ', padding) + line);
            }

            Console.WriteLine();

            // Display start message
            Console.WriteLine(new string(' ', padding) + "\t\t   Press any key to start...");

            // Wait for user input before continuing
            Console.ReadKey();
        }
        #endregion
    }
}
