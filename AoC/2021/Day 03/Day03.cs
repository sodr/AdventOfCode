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
            int[] bitSums = new int[numbers[0].Length];
            int gammaRate = 0, epsilonRate = 0;
            string result;

            // For every binary number
            foreach (var number in numbers)
            {
                // For every bit and bitsum
                for (int i = 0; i < number.Length; i++)
                {
                    // If '1', add 1 to sum, else subtract 1 from sum
                    bitSums[i] += number[i] == '1' ? 1 : -1;
                }
            }            

            // Reverse positionSum for bitwise operations
            Array.Reverse(bitSums); 

            // For every bit and bitsum
            for (int i = 0; i < bitSums.Length; i++)
            {
                // Check if sum is positive
                if (Convert.ToInt32(bitSums[i]) > 0)
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

            // Write result
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
