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

            // Check each command
            foreach (string command in commands)
            {
                string instruction = command.Split(" ")[0];     // Store instruction
                int value = int.Parse(command.Split(" ")[1]);   // Store value

                // Check instruction
                switch (instruction)
                {
                    // Go foward
                    case "forward":
                        position += value;
                        break;

                    // Go down
                    case "down":
                        depth += value;
                        break ;

                    // Go up
                    case "up":
                        depth -= value;
                        break;
                }
            }

            // Make result
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

            // Check each command
            foreach (var command in commands)
            {
                string instruction = command.Split(" ")[0];     // Store instruction
                int value = int.Parse(command.Split(" ")[1]);   // Store value

                // Check instruction
                switch (instruction)
                {
                    // Go foward
                    case "forward":
                        position += value;
                        depth += aim * value;
                        break;

                    // Aim down
                    case "down":
                        aim += value;
                        break;

                    // Aim up
                    case "up":
                        aim -= value;
                        break;
                }
            }

            // Make result
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
