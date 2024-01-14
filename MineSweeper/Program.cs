﻿// See https://aka.ms/new-console-template for more information
using MineSweeper;
using MineSweeper.Commands;
using MineSweeper.Validator;

Console.WriteLine("Welcome to Minesweeper!");

var consoleInputOutput = new ConsoleInputOutput();
var inputValidator = new InputValidator();
var consoleUserCommand = new ConsoleUserCommand(inputValidator);

var game = new Game(consoleInputOutput, consoleUserCommand);

game.Run();