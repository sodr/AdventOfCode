using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Advent_of_Code.Year_2021
{
    class Day01 : Puzzle
    {
        int[] inputvalues;

        public override string? Part1() 
        {
            // Make input a series of integers
            inputvalues = input.Split(Environment.NewLine).Select(int.Parse).ToArray();

            int counter = 0;

            // Go through each measurement
            for (int i = 1; i < inputvalues.Length; i++)
            {
                // Check if current measurement is bigger than the previous
                if (inputvalues[i] > inputvalues[i - 1])
                {
                    counter++;
                }
            }

            return counter.ToString();
        }

        public override string? Part2()
        {
            int oldSum = 0;
            int currentSum = 0;

            int counter = 0;            

            // Go through each measurement window
            for (int i = 0; i < inputvalues.Length - 2; i++)
            {
                // Store previous sum
                oldSum = currentSum;

                // Calculate sum
                currentSum = inputvalues[i] + inputvalues[i + 1] + inputvalues[i + 2];

                // Check if currentSum is bigger than the previous
                if (oldSum != 0 && currentSum > oldSum)
                {
                    counter++;
                }
            }

            return counter.ToString();
        }

        public Day01()
        {
            AutoSetFolderPath();
        }
       
    }
}
