using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    class Day03 : Puzzle
    {
        string result = String.Empty;

        // Create a sum of a bit position in numbers
        static int BitSum(string[] numbers, int position)
        {
            int bitSum = 0;

            // For every binary number
            foreach (string number in numbers)
            {
                // If '1', add 1 to sum, else subtract 1 from sum
                bitSum += number[position] == '1' ? 1 : -1;
            }

            return bitSum;
        }

        // Create a sum of each bit in numbers
        static int[] BitSums(string[] numbers)
        {
            int[] bitSums = new int[numbers[0].Length];

            // For every bit
            for (int i = 0; i < numbers[0].Length; i++)
            {
                // For every binary number
                foreach (string number in numbers)
                {
                    bitSums[i] = BitSum(numbers, i);
                }
            }

            return bitSums;
        }

        public override string? Part1()
        {
            string[]? numbers = input.Split(Environment.NewLine);
           
            int gammaRate = 0, epsilonRate = 0;

            // Get a sum of each bit
            int[] bitSums = BitSums(numbers);

            // Reverse positionSum for bitwise operations
            Array.Reverse(bitSums); 

            // For every bit and bitsum
            for (int i = 0; i < bitSums.Length; i++)
            {
                // Check if sum is positive
                if (bitSums[i] > 0)
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
            result += $"Power consumption: {gammaRate * epsilonRate}";

            return result;
        }

        public override string? Part2()
        {               
            string[]? numbers = input.Split(Environment.NewLine);

            string[] o2Numbers = numbers;
            string[] co2Numbers = numbers;

            // For every bit
            for (int i = 0; i < numbers[0].Length; i++)
            {
                // Check if we should continue to look for the oxygen generator rating
                if (o2Numbers.Length > 1)
                {
                    // Get the MOST common bit of all o2Numbers in position i
                    char mostCommonBit = BitSum(o2Numbers, i) >= 0 ? '1' : '0';

                    // Get sub array of numbers that have mostCommonBit in position i
                    o2Numbers = o2Numbers.Where(number => number[i] == mostCommonBit).ToArray();
                }

                // Check if we should continue to look for the CO2 scrubber rating
                if (co2Numbers.Length > 1)
                {
                    // Get the LEAST common bit of all co2Numbers in position i
                    char leastCommonBit = BitSum(co2Numbers, i) >= 0 ? '0' : '1';

                    // Get sub array of numbers that have leastCommonBit in position i
                    co2Numbers = co2Numbers.Where(number => number[i] == leastCommonBit).ToArray();
                }
            }

            // Convert rates from binary format to decimal
            int o2Rating = Convert.ToInt32(o2Numbers[0], 2);
            int co2Rating = Convert.ToInt32(co2Numbers[0], 2);

            // Write result
            result = $"O2 generator rating: {o2Rating}{Environment.NewLine}";
            result += $"CO2 scrubber rating: {co2Rating}{Environment.NewLine}";
            result += $"Life support rating: {o2Rating * co2Rating}";

            return result;
        }
             
        public Day03()
        {
            AutoSetFolderPath();
        }

    }
}
