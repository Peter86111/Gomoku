using Gomoku.GameControl;
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
        #region Fields
        private readonly Game _game;
        private readonly GameInfo _gameInfo;
        private readonly IRender _render;
        #endregion

        #region Constructor
        public MenuManager(Game game, GameInfo gameInfo, IRender render)
        {
            _game = game;
            _gameInfo = gameInfo;
            _render = render;
        }
        #endregion

        public int Menu(int number)
        {
            switch (number)
            {
                case 1:
                    _game.Run();
                    Console.ReadKey(true);
                    break;

                case 2:
                    Console.Clear();
                    _render.GetRuleInfo(_gameInfo);
                    break;

                case 3:
                    break;
            }

            return number;
        }
    }
}
