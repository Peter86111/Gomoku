using Gomoku.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Core
{
    public enum CellState
    {
        Empty,
        Black,
        White
    }
    internal class Board: IBoard
    {
        #region Fields
        private readonly int _size = 15;
        private readonly CellState[,] _field;
        #endregion

        #region Properties
        public int Size => _size;
        public CellState[,] Field => _field;
        #endregion

        #region Constructor
        public Board()
        {
            _field = new CellState[_size, _size];   // board size is 15x15
        }
        #endregion

        #region Methods       
        public CellState[,] GetBoardState()
        {
            return _field;
        }
        
        public void PlaceSymbol(int x, int y, CellState playerSymbol)
        {
            _field[x, y] = playerSymbol;
        }

        public bool IsValidMove(int x, int y)
        {
            bool isItBound = x >= 0 && x < _size && y >= 0 && y < _size;

            if (isItBound && _field[x, y] == CellState.Empty)
            {
                return true;
            }

            return false;
        }
        #endregion
    }
}
