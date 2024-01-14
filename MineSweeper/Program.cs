// See https://aka.ms/new-console-template for more information
using MineSweeper;
using MineSweeper.Commands;
using MineSweeper.Helper.NumbersHelper;
using MineSweeper.Operations;
using MineSweeper.Validator;

var inputValidator = new ConsoleInputValidator();
var consoleInputOutput = new ConsoleInputOutput();
var consoleUserCommand = new ConsoleUserCommand(inputValidator, consoleInputOutput);

var randomeGenerator = new RandomGenerator();
var mineFieldGenerator = new MineFieldGenerator(randomeGenerator);

var gameGenerator = new GameGenerator(consoleUserCommand, consoleInputOutput, mineFieldGenerator);

gameGenerator.Run();