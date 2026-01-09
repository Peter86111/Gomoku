using Gomoku.Core;
using Gomoku.Graphics;
using Gomoku.Input;
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
        Board board = new Board();
        Render render = new Render();
        WinCondition winCondition = new WinCondition();
        bool isGameOver = false;

        public void Run()
        {
            // Display the game title and wait for user interaction
            render.GetTitle();

            // --- Player setup phase ---

            // Ask for the first player's name and stone color
            var player1Name = GetPlayerName("\n\nFirst player name: ");
            var player1Stone = GetStone("Choose stone (1=Black, 2=White): ");

            // Ask for the second player's name and stone color
            var player2Name = GetPlayerName("\nSecond player name: ");
            var player2Stone = GetStone($"\n{player1Stone} stone is used by {player1Name}!\nChoose the free stone: ");

            // Ensure that both players do not choose the same stone color
            while (!CheckStoneColor(player1Stone, player2Stone))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{player1Stone} stone already taken. Please choose the other one.!\n");
                Console.ResetColor();

                player2Stone = GetStone($"{player2Name}!\nChoose the free stone: ");                
            }

            // Create player objects from the validated input
            var player1 = GetPlayer(player1Name, player1Stone);
            var player2 = GetPlayer(player2Name, player2Stone);

            // According to Gomoku rules, the black stone always starts
            Player currentPlayer = DetermineStartingPlayer(player1, player2);

            // Prepare the initial game board
            Console.Clear();
            board.GetBoardState();
            render.Board(board.Field);

            // Main game loop
            while (isGameOver != true)
            {
                // Display current player's turn
                Console.WriteLine($"\nCurrent player: {currentPlayer.Name} - [{currentPlayer.Stone} stone]");

                var input = new ConsoleInput();

                // Read move coordinates from the player
                var moveX = input.ReadInt("\nX (0–14): ");
                var moveY = input.ReadInt("Y (0–14): ");

                // Validate that the selected position is empty
                while (!board.IsValidMove(moveX, moveY))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nThis field is occupied. Try again.\n");
                    Console.ResetColor();

                    moveX = input.ReadInt("X (0–14): ");
                    moveY = input.ReadInt("Y (0–14): ");
                }

                Console.Clear();

                // Place the stone on the board
                var position = new Position(moveX, moveY);
                MakeMove(currentPlayer, position);

                // Check all possible win conditions from the last move
                bool win = winCondition.CheckWinHorizontally(board.Field, moveX, moveY) || winCondition.CheckWinVertically(board.Field, moveX, moveY) || winCondition.CheckWinMainDiagonally(board.Field, moveX, moveY) || winCondition.CheckWinAntiDiagonally(board.Field, moveX, moveY);

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
                board.GetBoardState();
                render.Board(board.Field);
            }


            #region Methods
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
            // Returns a StoneColor enum value
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
            bool CheckStoneColor(StoneColor stoneBlack, StoneColor stoneWhite)
            {
                if (stoneBlack == StoneColor.Black && stoneWhite == StoneColor.Black || stoneBlack == StoneColor.White && stoneWhite == StoneColor.White)
                {
                    return false;
                }

                return true;
            }

            // Places a stone on the board based on the player's color
            void MakeMove(Player player, Position position)
            {
                var cellState = player.Stone == StoneColor.Black ? CellState.Black : CellState.White;

                board.PlaceSymbol(position.X, position.Y, cellState);
            }           
            #endregion
        }
    }
}
