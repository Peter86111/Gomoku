using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Core;
using Gomoku.Menu;

namespace Gomoku.Interface
{
    internal interface IRender
    {
        void Board(CellState[,] cellState);
        void GetTitle();
        void CenterMenuText();
        void CenterRuleInfoText(GameInfo gameInfo);
        string CenterText(string prompt);
        string CenterWarningText(string prompt);
    }
}
