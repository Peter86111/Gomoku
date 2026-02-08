using Gomoku.Core;
using Gomoku.Graphics;
using Gomoku.Input;
using Gomoku.Interface;
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

            // Display the game title and wait for user interaction
            _render.GetTitle();

            // --- Player setup phase ---

            // Ask for the first player's name and stone color
            var player1Name = GetPlayerName("\n\nFirst player name: ");
            var player1Stone = GetStone("Choose stone (1=Black, 2=White): ");

            // Ask for the second player's name and stone color
            var player2Name = GetPlayerName("\nSecond player name: ");
            var player2Stone = GetStone($"\nChoose the free stone: ");

            // Ensure that both players do not choose the same stone color
            while (!CheckStoneColor(player1Stone, player2Stone))
            {
                player2Stone = GetStone($"\nChoose the free stone: ");
            }

            // Create player objects from the validated input
            var player1 = GetPlayer(player1Name, player1Stone);
            var player2 = GetPlayer(player2Name, player2Stone);

            // According to Gomoku rules, the black stone always starts
            Player currentPlayer = DetermineStartingPlayer(player1, player2);

            // Prepare the initial game board
            Console.Clear();
            var status = _board.GetBoardState();
            _render.Board(status);

            // Main game loop
            while (isGameOver != true)
            {
                // Display current player's turn
                Console.WriteLine($"\nCurrent player: {currentPlayer.Name} - [{currentPlayer.Stone} stone]");

                var input = new ConsoleInput();

                // Read move coordinates from the player
                var moveX = input.ReadString("\nX (A–O): ");
                var moveY = input.ReadInt("Y (0–14): ");

                // Validate that the selected position is empty
                while (!_board.IsValidMove(moveX, moveY))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThis field is occupied. Try again.\n");
                    Console.ResetColor();

                    moveX = input.ReadString("X (A–O): ");
                    moveY = input.ReadInt("Y (0–14): ");
                }

                Console.Clear();

                // Place the stone on the board
                var position = new Position(moveX, moveY);
                MakeMove(currentPlayer, position);

                // Check all possible win conditions from the last move
                bool win = _winCondition.CheckWinHorizontally(status, moveX, moveY) || _winCondition.CheckWinVertically(status, moveX, moveY) || _winCondition.CheckWinMainDiagonally(status, moveX, moveY) || _winCondition.CheckWinAntiDiagonally(status, moveX, moveY);

                if (win)
                {
                    // End the game and announce the winner
                    isGameOver = true;
                    Console.WriteLine($"Winner: {currentPlayer.Name} - [{currentPlayer.Stone} stone]!");
                }

                else
                {
                    // Switch to the other player
                    currentPlayer = currentPlayer == player1 ? player2 : player1;
                }

                // Redraw the board after each move
                _board.GetBoardState();
                _render.Board(status);
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
                        Console.WriteLine("\nName cannot be empty.");
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

                    else
                    {
                        Console.WriteLine($"Invalid input! Get a number: {black} or {white}.\n");
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

            // Ensures that two players do not use the same stone color
            bool CheckStoneColor(StoneColor blackStone, StoneColor whiteStone)
            {
                if (blackStone == StoneColor.Black && whiteStone == StoneColor.Black || blackStone == StoneColor.White && whiteStone == StoneColor.White)
                {
                    return false;
                }

                return true;
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
}
