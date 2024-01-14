// See https://aka.ms/new-console-template for more information
using MineSweeper;
using MineSweeper.Commands;
using MineSweeper.Helper.NumbersHelper;
using MineSweeper.Validator;

Console.WriteLine("Welcome to Minesweeper!");

var inputValidator = new InputValidator();
var consoleUserCommand = new ConsoleUserCommand(inputValidator);

var randomeGenerator = new RandomGenerator();
var mineField = new MineField(randomeGenerator);

var game = new Game(consoleUserCommand, mineField);

game.Run();