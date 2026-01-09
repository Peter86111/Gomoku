using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Core
{
    public enum StoneColor
    {
        Black,
        White
    }
    internal class Player
    {
        #region Fields
        private string _name;
        private readonly StoneColor _stone;        
        #endregion

        #region Properties        
        public string Name
        {
            get { return _name; }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new AggregateException("Player name cannot be empty or whitespace.");
                }

                _name = value;
            }
        }

        public StoneColor Stone => _stone;
        #endregion

        #region Constructor
        public Player(string name, StoneColor stoneColor)
        {            
            Name = name;
            _stone = stoneColor;
        }
        #endregion
    }
}
