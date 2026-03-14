using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Menu
{
    internal class GameInfo
    {
        public string GameRuleInfo()
        {
            string rules = @"Gomoku Rules
                    Objective: Be the first player to form an unbroken line of 5 stones horizontally, vertically, or diagonally.
                    Gameplay:
                    Players take turns placing one stone of their color on an empty intersection of the board.
                    Traditionally, Black (Player 1) starts the game.
                    Winning: The game ends immediately when a player creates a line of exactly 5 stones.
                    Draw: If the board is completely filled and no player has achieved a 5-stone row, the match is declared a draw.
                    Input: On your turn, enter the coordinates of your chosen move (e.g., A5) and press Enter.";            

            return rules;
        }
    }
}
