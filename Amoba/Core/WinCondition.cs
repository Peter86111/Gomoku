using Gomoku.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gomoku.Core
{
    internal class WinCondition: IWinCodition
    {
        // Check for horizontal winning lines from the last player's position
        public bool CheckWinHorizontally(CellState[,] field, int lastX, int lastY)
        {
            var currentState = field[lastX, lastY]; // state of the last move

            int countLeft = 0;
            int countRight = 0;

            for (int i = lastX + 1; i < field.GetLength(1); i++)    // check continous marks to the right of the starting position
            {
                if (field[i, lastY] == currentState)
                {
                    countRight++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            for (int i = lastX - 1; i >= 0; i--)    // check continous marks to the left of the starting position
            {
                if (field[i, lastY] == currentState)
                {
                    countLeft++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            int sum = countLeft + 1 + countRight;   // total continous marks inclulding the starting one

            if (sum >= 5)
            {
                return true;
            }

            return false;
        }

        // Check for vertical winning lines from the last player's position
        public bool CheckWinVertically(CellState[,] field, int lastX, int lastY)
        {
            var currentState = field[lastX, lastY]; // state of the last move

            int countDown = 0;
            int countUp = 0;

            for (int i = lastY + 1; i < field.GetLength(0); i++)    // check continous marks to the down of the starting position
            {
                if (field[lastX, i] == currentState)
                {
                    countDown++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            for (int i = lastY - 1; i >= 0; i--)    // check continous marks to the up of the starting position
            {
                if (field[lastX, i] == currentState)
                {
                    countUp++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            int sum = countDown + 1 + countUp;   // total continous marks inclulding the starting one

            if (sum >= 5)
            {
                return true;
            }

            return false;
        }

        // Check for main diagonal (right, down - left, up) winning lines from the last player's position
        public bool CheckWinMainDiagonally(CellState[,] field, int lastX, int lastY)
        {
            var currentState = field[lastX, lastY]; // state of the last move

            int countPrev = 0;
            int countNext = 0;

            int prevX = lastX - 1;
            int prevY = lastY - 1;

            int nextX = lastX + 1;
            int nextY = lastY + 1;

            for (; nextX < field.GetLength(1) && nextY < field.GetLength(0); nextX++, nextY++)  // check continuous marks diagonally (right-down) from the starting position
            {
                if (field[nextX, nextY] == currentState)
                {
                    countNext++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            for (; prevX >= 0 && prevY >= 0; prevX--, prevY--)  // check continuous marks diagonally (left-up) from the starting position
            {
                if (field[prevX, prevY] == currentState)
                {
                    countPrev++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            int sum = countPrev + 1 + countNext;    // total continous marks inclulding the starting one

            if (sum >= 5)
            {
                return true;
            }

            return false;
        }

        // Check for right diagonal (right, up - left, down) winning lines from the last player's position
        public bool CheckWinAntiDiagonally(CellState[,] field, int lastX, int lastY)
        {
            var currentState = field[lastX, lastY]; // state of the last move

            int countUp = 0;
            int countDown = 0;

            int nextUpX = lastX + 1;
            int nextUpY = lastY - 1;

            int nextDownX = lastX - 1;
            int nextDownY = lastY + 1;

            for (; nextUpX < field.GetLength(1) && nextUpY >= 0; nextUpX++, nextUpY--)  // check continuous marks diagonally (right-up) from the starting position
            {
                if (field[nextUpX, nextUpY] == currentState)
                {
                    countUp++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            for (; nextDownX >= 0 && nextDownY < field.GetLength(0); nextDownX--, nextDownY++)  // check continuous marks diagonally (left-down) from the starting position
            {
                if (field[nextDownX, nextDownY] == currentState)
                {
                    countDown++;
                }

                else
                {
                    break;  // if not player stop the count
                }
            }

            int sum = countDown + 1 + countUp;   // total continous marks inclulding the starting one

            if (sum >= 5)
            {
                return true;
            }

            return false;
        }
    }
}
