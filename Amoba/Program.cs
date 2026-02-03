using Gomoku.Core;
using Gomoku.GameControl;
using Gomoku.Graphics;
using Gomoku.Input;
using Gomoku.Interface;
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

            var game = new Game(board, render, winCodition);
            game.Run();
        }
    }
}