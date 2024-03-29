﻿using MineSweeper.Helper.NumbersHelper;
using MineSweeper.Models;

namespace MineSweeper
{
    public class MineFieldGenerator
    {
        private readonly IRandomGenerator _randomGenerator;

        public MineField MineField { get; set; }

        public MineFieldGenerator(IRandomGenerator randomGenerator) 
        { 
           _randomGenerator = randomGenerator;
           MineField = new MineField();
        }

        public void Initialize(int gridSize, int mines)
        {
            MineField.GridSize = gridSize;
            MineField.Squares = new List<MineSquare>();

            GenerateInitialMineField(gridSize);
            PlaceMinesRandomly(gridSize, mines);
        }

        public void GenerateInitialMineField(int gridSize)
        {
            for (var i = 0; i < gridSize; i++)
            {
                for (var j = 0; j < gridSize; j++)
                {
                    var square = new MineSquare(i, j);
                    MineField.Squares.Add(square);
                }
            }
        }

        public void PlaceMinesRandomly(int gridSize, int mines)
        {
            //Assume squares are numbered like below as squareNumbers
            // 0 1 2
            // 3 4 5
            // 6 7 8

            var randomSquares = _randomGenerator.GenerateRandomIntegers(mines, gridSize * gridSize - 1);
            foreach (var squareNumber in randomSquares)
            {
                var x = squareNumber / gridSize;
                var y = squareNumber % gridSize;

                var mineSquare = MineField.Squares.FirstOrDefault(s => s.X == x && s.Y == y);
                mineSquare.IsMine = true;
            }
        }

        public bool CheckAllMinesRevealed()
        {
            return MineField.Squares.All(s => s.IsRevealed || s.IsMine);
        }

        public MineSquare GetSquareByPosition(int x, int y)
        {
            var fieldSquare = MineField.Squares.Single(s => s.X == x && s.Y == y);
            return fieldSquare;
        }

        public int RevealSquare(MineSquare fieldSquare)
        {
            if (fieldSquare.IsRevealed) return fieldSquare.NumberOfMinesAround;

            var count = 0;
            for(var i = -1; i < 2; i++)
            {
                for(var j = -1;j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;

                    var x = fieldSquare.X - i;
                    var y = fieldSquare.Y - j;

                    if(x < 0 || x > MineField.GridSize -1 || y < 0 || y > MineField.GridSize -1) continue;

                    var neighbour = MineField.Squares.Single(s => s.X == x && s.Y == y);
                    if (neighbour.IsMine)
                    {
                        count++;
                    }
                }
            }

            fieldSquare.NumberOfMinesAround = count;
            fieldSquare.IsRevealed = true;

            return count;
        }

        public void UpdateMineField(MineSquare square)
        {
            if (square.NumberOfMinesAround != 0)
                return;

            for(var i=-1;  i<2; i++)
            {
                for(var j=-1; j<2; j++)
                {
                    if (i == 0 && j == 0) continue;

                    var x = square.X - i;
                    var y = square.Y - j;

                    if (x < 0 || x > MineField.GridSize - 1 || y < 0 || y > MineField.GridSize - 1) continue;

                    var neighbour = MineField.Squares.Single(s => s.X == x && s.Y == y );

                    if (neighbour.IsRevealed) continue;

                    var adjacentMines = RevealSquare(neighbour);
                    if (adjacentMines == 0)
                    {
                        UpdateMineField(neighbour);
                    }
                }
            }
        }
    }
}
