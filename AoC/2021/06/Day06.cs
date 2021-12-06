using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Year_2021
{
    internal class Day06 : Puzzle
    {      
        string CalculateFishes(int days)
        {
            // Observe the fishes
            List<long> lanternFishes = Array.ConvertAll(input.Split(","), long.Parse).ToList();

            // Count the fishes
            long[] fishes = new long[9];
            for (int i = 0; i < fishes.Length; i++)
            {
               fishes[i] = lanternFishes.Where(x => x == i).Count();
            }

            // For every day
            for (int day = 1; day <= days; day++)
            {
                // Count the fishes that are about to reproduce            //                           ,--...,
                long newFishes = fishes[0];                                //                          .''-..'     _
                                                                           //                         /@    `.-:  _/`
                // Move all fishes -1 day                                  //                         > )<  ,-.: (_)
                for (int i = 1; i < fishes.Length; i++)                    //                          `..-',:-
                {                                                          //                    ,--..   `-'
                    fishes[i-1] = fishes[i];                               //                   .''-.,'     _
                }                                                          //                  /@    `.-:  (_)
                                                                           //                  > )<  ,-.:   +
                // Reset motherfishes                                      //                   `..-',` 
                fishes[6] += newFishes;                                    //                     `-'

                // Add new born baby fishes
                fishes[8] = newFishes;        // Aww! They are super cute!            >('>
            }

            // Count the number of fishes
            long numberOfFishes = fishes.Sum();
            return $"Number of lanternfishes after {days} days: {numberOfFishes}";
        }

        public override string? Part1()
        {
            return CalculateFishes(days: 80);
        }

        public override string? Part2()
        {
            return CalculateFishes(days: 256);
        }

        public Day06()
        {
            AutoSetFolderPath();
        }
    }
}
