# ConnectFour
A fun game for two players, reimagined as a 1980's console game

## Setup
To compile the game from scratch, you will need Visual Studio 2017. Simply clone the repository into your local directory, then double click the solution file to open it up. You can then run the game direct from VisualStudio, or download the compiled binary at http://www.jhray.com/ConnectFour.zip

## Objectives
Get four in a row to win! 

## Rules
Players take turns to pick which column to populate with their token. Yellow goes first. You can only populate a row if there is a black space ("o") there available. A space is populated by you if it's either "y" or "r" depending on if you're yellow or red. No two tokens can be in the same space at the same time. A player must make a move, even if there are no good moves to make.

Confound your opponents by laying clever traps, forcing them into moves that will result in them losing.

## The game board
The dimensions of the game board are up to you! There are only 3 rules

1. There must be at least 8 spaces to play
2. One dimension must be at lease 4 long (width or height)
3. There's no such thing as negative or zero dimensions. Positive numbers only!

## Features
- To leave the game, type "exit" or "quit" whenever you want
- Supports two players. 
- Supports one game per run only.
