# Gomoku (Five in a Row) – Console Application

This project is a console-based implementation of the classic Gomoku (Five in a Row) game, written in C#.

The main goal of this project is learning and practicing:
- Object-Oriented Programming principles
- Console rendering
- Game logic separation
- Clean and readable code structure

---

## Features

- Two-player local gameplay
- Unicode-based board rendering
- Centered ASCII title screen

---

## Key Architectural Features
- **Inversion of Control (IoC) & Dependency Injection (DI)**: The project follows modern SOLID principles. The `Game` engine is decoupled from its dependencies (Board, Renderer, WinCondition) using constructor injection and interfaces, making the codebase highly testable and maintainable.

---

## Current State

**This project is under active development.**

Planned improvements:
- Menu system
- Improved text and input alignment
- Code refactoring and documentation expansion
- Possible AI opponent (future goal)

---

## Why this project?

This repository also serves as a **learning reference** and a **portfolio project**.
Some parts may be improved later as my knowledge grows.

---

## Learning & Acknowledgements

This project was developed as part of a self-learning journey in C# and software development.

During development, I received guidance and conceptual explanations from ChatGPT (OpenAI),
which helped me better understand design decisions, code structure, and best practices.

All code was written, tested, and integrated by me as part of the learning process.
The goal of this project is to reflect my current understanding and continuous improvement.

## How to Run

- Clone the repository
- Open in Visual Studio
- Build and run the console application
