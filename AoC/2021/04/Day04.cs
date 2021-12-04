using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    internal class Day04 : Puzzle
    {       
        internal class Number
        {
            public int Row;
            public int Col;
            public bool Marked;
            public int Value;
        }

        internal class Board
        {
            public int Id;
            public int MarkedNumbersCount;
            public bool Winner;
            public List<Number> Numbers = new();
        }

        static List<Board> CreateBoardsFromStrings(List<string> inputLines)
        {
            List<Board> boards = new();

            int currentID = 0;
            int currentRow = 0;
            int currentCol = 0;

            // Create first board
            Board currentBoard = new()
            {
                Id = currentID++,
            };

            // For every row
            for (int i = 0; i < inputLines.Count(); i++)
            {
                // Check if we are on a bingo board
                if (inputLines[i] != string.Empty)
                {
                    // Get all numbers in row
                    int[]? rowNumbers = Array.ConvertAll(inputLines[i].Split(" ", StringSplitOptions.RemoveEmptyEntries), int.Parse);

                    // For every number on the row
                    foreach (int number in rowNumbers)
                    {
                        // Create a board number
                        Number boardNumber = new()
                        {
                            Row = currentRow,
                            Col = currentCol++,
                            Marked = false,
                            Value = number,
                        };

                        // Add number to board
                        currentBoard.Numbers.Add(boardNumber);

                    }
                    currentRow++;

                    // Reset current col
                    currentCol = 0;
                }
                else
                {
                    // Add board to boards
                    boards.Add(currentBoard);

                    // Create a new board
                    currentBoard = new()
                    {
                        Id = currentID++,
                    };

                    // Reset current row
                    currentRow = 0;
                }               
            }
            return boards;
        }

        private static int[]? CheckBingo(Board board, Number bingoNumber)
        {
            var bingoRow = board.Numbers.Where(x => x.Row == bingoNumber.Row && x.Marked);
            var bingoCol = board.Numbers.Where(x => x.Col == bingoNumber.Col && x.Marked);

            // Check row
            if (bingoRow.Count() == 5)
            {
                // BINGO!
                return bingoRow.OrderBy(x => x.Value).Select(x => x.Value).ToArray();
            }

            // Check col
            if (bingoCol.Count() == 5)
            {
                // BINGO!
                return bingoCol.OrderBy(x => x.Value).Select(x => x.Value).ToArray();
            }

            // no bingo :(
            return null;
        }

        public string? PlayBingo(bool stopWhenBingo)
        {
            List<string> inputLines = input.Split(Environment.NewLine).ToList();
            Board? winningBoard = null;
            int[]? winningNumbers = null;
            int winningNumber = 0;
            string? result = null;

            // Get numbers to draw
            List<int> numbersToDraw = Array.ConvertAll(inputLines[0].Split(","), int.Parse).ToList();

            // Remove non board input
            inputLines.RemoveRange(0, 2);

            // Get boards
            List<Board>? boards = CreateBoardsFromStrings(inputLines);

            // Draw a number
            foreach (int drawnNumber in numbersToDraw)
            {
                // Get all boards that contains the drawn number (and is not a winner)
                foreach (Board board in boards.Where(x => x.Numbers.Any(n => n.Value == drawnNumber) && !x.Winner))
                {
                    // Find the drawn number on the board
                    foreach (Number bingoNumber in board.Numbers.Where(n => n.Value == drawnNumber))
                    {
                        // Mark the number on the board
                        bingoNumber.Marked = true;
                        board.MarkedNumbersCount++;

                        // Check board for bingo
                        winningNumbers = CheckBingo(board, bingoNumber);
                        if (winningNumbers != null)
                        {
                            // BINGO!
                            board.Winner = true;
                            winningBoard = board;
                            winningNumber = drawnNumber;                            
                        }
                    }

                    // Check if we should stop playing
                    if (stopWhenBingo && winningBoard != null)
                    {
                        goto EXIT; // Exit all loops
                    }
                }              
            } EXIT:

            // Write result
            if (winningBoard != null && winningNumbers != null)
            {
                int umarkedNumbersSum = winningBoard?.Numbers.Where(x => !x.Marked).Sum(x => x.Value) ?? 0;
                result = $"Winning board: {winningBoard?.Id}{Environment.NewLine}";
                result += $"Winning numbers: {string.Join(", ", winningNumbers)}{Environment.NewLine}";
                result += $"Score: {winningNumber * umarkedNumbersSum}";
            }            

            return result;
        }

        public override string? Part1()
        {
            return PlayBingo(true);
        }

        public override string? Part2()
        {
            return PlayBingo(false);
        }   

        public Day04()
        {
            AutoSetFolderPath();
        }
    }
}
