# Gomoku

**A simple console-based Gomoku game in C#.**

This is my first independent game project, implementing the classic Gomoku (Five in a Row) game. The goal is to place five identical marks (X or O) in a row on a 10x10 board—horizontally, vertically, or diagonally.

## Key Features

- Console-based gameplay with colored output

- Simple player interaction: players take turns selecting a row and column

- Current version: beta. The main focus is implementing correct win detection

## Known Issues

- Win checking is under development. Some edge cases may not be handled correctly

- Currently, the game loop does not always stop automatically after a win

- If a player chooses an occupied cell, the game does not yet prompt for a retry

## Planned Improvements

- Complete and bug-free win detection in all directions

- Improved gameplay flow: automatic end-of-game and retries for occupied cells

- Customizable board size and win conditions

- Graphical enhancements and scoring/statistics

## How to Play
1. Clone the repository:
```bash
git clone <repository-url>
