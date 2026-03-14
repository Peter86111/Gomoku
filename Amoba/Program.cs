using Gomoku.Core;
using Gomoku.GameControl;
using Gomoku.Graphics;
using Gomoku.Input;
using Gomoku.Interface;
using Gomoku.Menu;
using System.Collections.Specialized;
using System.Net;

namespace Gomoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new Board();
            IWinCodition winCodition = new WinCondition();
            IRender render = new Render();
            GameInfo gameInfo = new GameInfo();
            ConsoleInput input = new ConsoleInput();

            var game = new Game(board, render, winCodition);            

            MenuManager menuManager = new MenuManager(game, gameInfo, render);           

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                // Display the game title and wait for user interaction
                render.GetTitle();

                // Menu
                render.GetMenu();

                var numberOfMenu = input.ReadIntForMenu(render.CenterText("Select an option: "));                

                if (numberOfMenu < 1 || numberOfMenu > 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(render.CenterText("Invalid input! Try again between 1 and 3."));
                    Console.ResetColor();
                    Console.ReadKey();
                }

                else
                {
                    var choise = menuManager.Menu(numberOfMenu);

                    if (choise == 2)
                    {
                        Console.WriteLine(render.CenterText("Press any key to continue..."));

                        // Wait for user input before continuing
                        Console.ReadKey(true);
                    }

                    else if (choise == 3)
                    {
                        isRunning = false;
                        Console.WriteLine(render.CenterText("Goodbye!"));
                    }
                }
            }
        }
    }
}