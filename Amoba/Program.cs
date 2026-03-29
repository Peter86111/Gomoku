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
            IRender render = new Render();
            ConsoleInput input = new ConsoleInput();
            MenuManager menuManager = new MenuManager();           

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
                    Console.WriteLine(render.CenterWarningText("Invalid input! Try again between 1 and 3."));

                    // Wait for user input before continuing
                    Console.ReadKey(true);
                }

                else
                {
                    var choise = menuManager.Menu(numberOfMenu);

                    if (choise == 2)
                    {
                        Console.WriteLine(render.CenterText("Press any key to continue..."));                        
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