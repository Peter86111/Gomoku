using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Core;

namespace Gomoku.Interface
{
    internal interface IBoard
    {
        CellState[,] GetBoardState();
        void PlaceSymbol(int x, int y, CellState playerSymbol);
        bool IsValidMove(int x, int y);
    }
}
