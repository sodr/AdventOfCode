using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    class Day02 : Puzzle
    {
        public override string? Part1()
        {
            string[]? commands = input.Split(Environment.NewLine);
            string result;
            int position = 0, depth = 0;

            foreach (string command in commands)
            {
                string instruction = command.Split(" ")[0];
                int value = int.Parse(command.Split(" ")[1]);

                switch (instruction)
                {
                    case "forward":
                        position += value;
                        break;

                    case "down":
                        depth += value;
                        break ;

                    case "up":
                        depth -= value;
                        break;
                }
            }

            result = $"Position: {position}{Environment.NewLine}";
            result += $"Depth: {depth}{Environment.NewLine}";
            result += $"Answer: {position*depth}";

            return result;
        }

        public override string? Part2()
        {
            string[]? commands = input.Split(Environment.NewLine);
            string result;
            int position = 0, depth = 0, aim = 0;

            foreach (var command in commands)
            {
                string instruction = command.Split(" ")[0];
                int value = int.Parse(command.Split(" ")[1]);

                switch (instruction)
                {
                    case "forward":
                        position += value;
                        depth += aim * value;
                        break;

                    case "down":
                        aim += value;
                        break;

                    case "up":
                        aim -= value;
                        break;
                }
            }

            result = $"Position: {position}{Environment.NewLine}";
            result += $"Depth: {depth}{Environment.NewLine}";
            result += $"Answer: {position * depth}";

            return result;
        }
             
        public Day02()
        {
            AutoSetFolderPath();
        }

    }
}
