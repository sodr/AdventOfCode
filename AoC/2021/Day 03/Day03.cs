using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    class Day03 : Puzzle
    {
        public override string? Part1()
        {
            string[]? numbers = input.Split(Environment.NewLine);
            int[] bitSum = new int[numbers[0].Length];
            int gammaRate = 0, epsilonRate = 0;
            string result;

            // For every binary number
            foreach (var number in numbers)
            {
                // For every bit
                for (int i = 0; i < number.Length; i++)
                {
                    // Add one to Sum if 1, else subtract 1
                    bitSum[i] += number[i] == '1' ? 1 : -1;
                }
            }            

            // Reverse positionSum for bitwise operations
            Array.Reverse(bitSum); 

            // For every sum and bit position
            for (int i = 0; i < bitSum.Length; i++)
            {
                // Check if sum is positive
                if (Convert.ToInt32(bitSum[i]) > 0)
                {
                    gammaRate |= 1 << i;        // Set bit on position i
                    epsilonRate &= ~(1 << i);   // Reset bit on position i
                }
                else
                {
                    gammaRate &= ~(1 << i);     // Reset bit on position i
                    epsilonRate |= 1 << i;      // Set bit on position i
                }

            }

            result = $"Gamma rate: {gammaRate}{Environment.NewLine}";
            result += $"Epsilon rate: {epsilonRate}{Environment.NewLine}";
            result += $"Answer: {gammaRate * epsilonRate}";

            return result;
        }

        public override string? Part2()
        {            
            return null;
        }
             
        public Day03()
        {
            AutoSetFolderPath();
        }

    }
}
