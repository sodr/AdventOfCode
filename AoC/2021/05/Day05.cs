using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    internal class Day05 : Puzzle
    {
        internal class Point
        {
            public int X;
            public int Y;
        }

        internal class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }

            public void ReverseHorisontal()
            {
                int X = End.X;
                End.X = Start.X;
                Start.X = X;
                
            }
            public void ReverseVertical()
            {
                int Y = End.Y;
                End.Y = Start.Y;
                Start.Y = Y;
            }

            public Line()
            {
                Start = new Point();
                End = new Point();
            }
        }

        public override string? Part1()
        {
            List<string> inputLines = input.Split(Environment.NewLine).ToList();
            List<Line> lines = GetLines(inputLines);

            // Create ocean floor
            sbyte[,] oceanFloor = new sbyte[
                Math.Max(lines.Max(y => y.Start.Y), lines.Max(y => y.End.Y)) + 1,
                Math.Max(lines.Max(x => x.Start.X), lines.Max(x => x.End.X)) + 1
            ];

            var horizontalLines = lines.Where(a => a.Start.Y == a.End.Y).ToList();
            var verticalLines = lines.Where(a => a.Start.X == a.End.X).ToList();

            foreach (var line in horizontalLines)
            {              
                if (line.Start.X > line.End.X)
                    line.ReverseHorisontal();

                var y = line.Start.Y;
                for (int x = line.Start.X; x <= line.Start.X + (line.End.X - line.Start.X); x++)
                {
                    oceanFloor[y, x]++;
                    //Print(WriteOceanFloor(oceanFloor));
                }                
            }


            foreach (var line in verticalLines)
            {
                if (line.Start.Y > line.End.Y)
                    line.ReverseVertical();

                var x = line.Start.X;
                for (int y = line.Start.Y; y <= line.Start.Y + (line.End.Y - line.Start.Y); y++)
                {
                    oceanFloor[y, x]++;
                    //Print(WriteOceanFloor(oceanFloor));
                }
            }

            int lineOverlaps = 0;
            for (int i = 0; i < oceanFloor.GetLength(0); i++)
            {
                for (int j = 0; j < oceanFloor.GetLength(1); j++)
                {
                    lineOverlaps += oceanFloor[i, j] >= 2 ? 1 : 0;
                }
                
            }

            //string result = String.Empty;
            string result = WriteOceanFloor(oceanFloor) + Environment.NewLine;
            result += $"Overlaping lines: {lineOverlaps}";

            return result;
        }

        internal void Print(string output)
        {
            output1 = output;
            WriteOutput();
        }

        private string WriteOceanFloor(sbyte[,] oceanFloor)
        {
            string output = "";
            for (int i = 0; i < oceanFloor.GetLength(0); i++)
            { 
                for (int j = 0; j < oceanFloor.GetLength(1); j++)
                {
                    output += oceanFloor[i, j];// == 0 ? "." : oceanFloor[i, j];
                }
                output += Environment.NewLine;
            }
            return output;
        }

        private static List<Line> GetLines(List<string> inputLines)
        {
            List<Line> lines = new();

            foreach (string inputLine in inputLines)
            {
                string[]? pointsText = inputLine.Split(" -> ");
                Point[] points = new Point[]
                {
                    new Point{
                        X = Convert.ToInt32(pointsText[0].Split(",")[0]),
                        Y = Convert.ToInt32(pointsText[0].Split(",")[1]),
                    },
                    new Point{
                        X = Convert.ToInt32(pointsText[1].Split(",")[0]),
                        Y = Convert.ToInt32(pointsText[1].Split(",")[1]),
                    }
                };
                
                lines.Add(new Line{ Start = points[0], End = points[1] });
            }

            return lines;
        }

        public override string? Part2()
        {
            return null;
        }

        public Day05()            
        {
            AutoSetFolderPath();
        }
    }
}
