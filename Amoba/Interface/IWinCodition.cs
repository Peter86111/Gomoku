using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomoku.Core;

namespace Gomoku.Interface
{
    internal interface IWinCodition
    {
        bool CheckWinHorizontally(CellState[,] field, int lastX, int lastY);
        bool CheckWinVertically(CellState[,] field, int lastX, int lastY);
        bool CheckWinMainDiagonally(CellState[,] field, int lastX, int lastY);
        bool CheckWinAntiDiagonally(CellState[,] field, int lastX, int lastY);

    }
}
