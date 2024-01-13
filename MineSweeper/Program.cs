﻿// See https://aka.ms/new-console-template for more information
using MineSweeper;
using MineSweeper.Commands;
using MineSweeper.Validator;

Console.WriteLine("Welcome to Minesweeper!");

var consoleCommand = new ConsoleCommand();
var inputValidator = new InputValidator();


var game = new Game(consoleCommand, inputValidator);

game.Run();