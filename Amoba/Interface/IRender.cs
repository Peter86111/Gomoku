using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Core;

namespace Gomoku.Interface
{
    internal interface IRender
    {
        void Board(CellState[,] cellState);
        void GetTitle();
    }
}
