using Gomoku.Core;
using Gomoku.Graphics;
using Gomoku.Input;
using Gomoku.Interface;
using Gomoku.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.GameControl
{
    internal class Game
    {
        #region Field
        private readonly IBoard _board;
        private readonly IRender _render;
        private readonly IWinCodition _winCondition;
        #endregion

        #region Constructor
        public Game(IBoard board, IRender render, IWinCodition winCodition)
        {
            _board = board;
            _render = render;
            _winCondition = winCodition;
        }
        #endregion        

        #region Methods
        public void Run()
        {
            bool isGameOver = false;

            _render.GetTitle();

            // --- Player setup phase ---

            // Ask for the first player's name and stone color
            var player1Name = GetPlayerName(_render.CenterText("First player name: "));
            var player1Stone = GetStone(_render.CenterText("Choose stone (1=Black, 2=White): "));

            // Ask for the second player's name
            var player2Name = GetPlayerName(_render.CenterText("Second player name: "));
            var player2Stone = player1Stone == StoneColor.Black ? StoneColor.White : StoneColor.Black;  // Second player uses free stone automatically

            // Create player objects from the validated input
            var player1 = GetPlayer(player1Name, player1Stone);
            var player2 = GetPlayer(player2Name, player2Stone);

            // According to Gomoku rules, the black stone always starts
            Player currentPlayer = DetermineStartingPlayer(player1, player2);

            var input = new ConsoleInput();            

            // Main game loop
            while (!isGameOver)
            {
                // Prepare the initial game board
                Console.Clear();
                var status = _board.GetBoardState();
                _render.Board(status);

                // Display current player's turn
                Console.WriteLine(_render.CenterText($"Current player: {currentPlayer.Name} - [{currentPlayer.Stone} stone]"));

                // Standard states
                int moveX = 0;
                int moveY = 0;

                while (true)
                {
                    // Read move coordinates from the player
                    moveX = input.ReadString(_render.CenterText("X (A–O): "));
                    moveY = input.ReadInt(_render.CenterText("Y (0–14): "));

                    if (moveX < 0 || moveX > 14)
                    {
                        Console.WriteLine(_render.CenterWarningText("Invalid input! Try again between 'A' and 'O'."));
                        Console.ReadKey(true);
                    }

                    else if (moveY < 0 || moveY > 14)
                    {
                        Console.WriteLine(_render.CenterWarningText("Invalid input! Try again between 0 and 14."));
                        Console.ReadKey(true);
                    }

                    // Validate that the selected position is empty
                    else if (!_board.IsValidMove(moveX, moveY))
                    {
                        Console.WriteLine(_render.CenterWarningText("This field is occupied. Try again."));
                        Console.ReadKey(true);
                    }

                    else
                    {
                        break;
                    }
                }

                Console.Clear();

                // Place the stone on the board
                var position = new Position(moveX, moveY);
                MakeMove(currentPlayer, position);

                // Redraw the board after each move
                status = _board.GetBoardState();
                _render.Board(status);

                // Check all possible win conditions from the last move
                bool win = _winCondition.CheckWinHorizontally(status, moveX, moveY) || _winCondition.CheckWinVertically(status, moveX, moveY) || _winCondition.CheckWinMainDiagonally(status, moveX, moveY) || _winCondition.CheckWinAntiDiagonally(status, moveX, moveY);

                if (win)
                {
                    // End the game and announce the winner
                    isGameOver = true;
                    Console.WriteLine(_render.CenterText($"Winner: {currentPlayer.Name} - [{currentPlayer.Stone} stone]!"));
                }

                else
                {
                    // Switch to the other player
                    currentPlayer = currentPlayer == player1 ? player2 : player1;
                }
            }
        }

        // Reads and validates a player's name from the console
        // Ensures that the name is not empty or whitespace
        string GetPlayerName(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(line))
                {
                    line = Console.ReadLine();
                }

                else
                {
                    return line;
                }
            }
        }

        // Reads and validates the selected stone color
        // Return a StoneColor enum value
        StoneColor GetStone(string prompt)
        {
            int black = 1;
            int white = 2;

            while (true)
            {
                Console.Write(prompt);
                string line = Console.ReadLine();

                if (int.TryParse(line, out int number) && number >= black && number <= white)
                {
                    return number == black ? StoneColor.Black : StoneColor.White;
                }
            }
        }

        // Creates a Player instance from validated input data
        Player GetPlayer(string playerName, StoneColor playerStone)
        {
            Player player = new Player(playerName, playerStone);

            return player;
        }

        // Determines which player starts the game
        // According to Gomoku rules, black always starts
        Player DetermineStartingPlayer(Player player1, Player player2)
        {
            player1 = player1.Stone == StoneColor.Black ? player1 : player2;

            return player1;
        }

        // Places a stone on the board based on the player's color
        void MakeMove(Player player, Position position)
        {
            var cellState = player.Stone == StoneColor.Black ? CellState.Black : CellState.White;

            _board.PlaceSymbol(position.X, position.Y, cellState);
        }
        #endregion
    }
}
