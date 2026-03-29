using Gomoku.Core;
using Gomoku.GameControl;
using Gomoku.Graphics;
using Gomoku.Input;
using Gomoku.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Menu
{
    internal class MenuManager
    {
        IRender render = new Render();
        GameInfo gameInfo = new GameInfo();     

        public int Menu(int number)
        {
            switch (number)
            {
                case 1:
                    IBoard board = new Board();                    
                    IWinCodition winCodition = new WinCondition();

                    var game = new Game(board, render, winCodition);
                    game.Run();
                    Console.ReadKey(true);
                    break;

                case 2:
                    Console.Clear();
                    render.CenterRuleInfoText(gameInfo);
                    break;

                case 3:
                    break;
            }

            return number;
        }
    }
}
