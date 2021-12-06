using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    internal class Day06 : Puzzle
    {
        string CalculateFishes(int days, bool printFishes = false)
        {
            List<int> lanternFishes = Array.ConvertAll(input.Split(","), int.Parse).ToList();

            string result = "Initial state: " + string.Join(", ", lanternFishes) + Environment.NewLine;

            for (int day = 1; day <= days; day++)
            {
                int numberOfFishes = lanternFishes.Count();
                for (int i = 0; i < numberOfFishes; i++)
                {
                    lanternFishes[i]--;

                    if (lanternFishes[i] == -1)
                    {
                        lanternFishes[i] = 6;
                        lanternFishes.Add(8);
                    }

                }

                if (printFishes)
                {
                    string s = day == 1 ? " day:  " : " days: ";
                    result += $"After {day.ToString().PadLeft(2)}{s}{string.Join(", ", lanternFishes)}{Environment.NewLine}";
                }                
            }

            string fishesResult = $"Number of fishes: {lanternFishes.Count()}{Environment.NewLine}{Environment.NewLine}";

            return fishesResult + result;
        }

        public override string? Part1()
        {
            return CalculateFishes(days: 80, printFishes: true);
        }

        public override string? Part2()
        {
            return null; // CalculateFishes(days: 256, printFishes: false);
        }

        public Day06()
        {
            AutoSetFolderPath();
        }
    }
}
