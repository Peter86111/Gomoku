using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Core
{
    internal class Position
    {
        #region Fields
        private int _x;
        private int _y;
        #endregion

        #region Properties
        public int X
        {
            get { return _x; }

            set
            {
                if ((value < 0) || (value > 14))
                {
                    throw new ArgumentException("Invalid input! Try again between 0 and 14.");
                }

                else
                {
                    _x = value;
                }
            }
        }

        public int Y
        {
            get { return _y; }

            set
            {
                if ((value < 0) || (value > 14))
                {
                    throw new ArgumentException("Invalid input! Try again between 0 and 14.");
                }

                else
                {
                    _y = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
        #endregion
    }
}
