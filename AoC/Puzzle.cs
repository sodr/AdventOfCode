using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Advent_of_Code
{
    interface IPuzzle
    {
        string? inputPath { get; set; }
        string? output1Path { get; set; }
        string? output2Path { get; set; }

        void Main();
    }

    abstract class Puzzle : IPuzzle
    {   
        public string? inputPath { get; set; }
        public string? output1Path { get; set; }
        public string? output2Path { get; set; }

        public abstract void Main();

        internal string? input;
        internal string? output1;
        internal string? output2;

        public void ReadInput()
        {
            if (!string.IsNullOrEmpty(inputPath))
            {
                input = System.IO.File.ReadAllText(inputPath);
            }
            else
            {
                throw new Exception("no input path");
            }
        }

        public void WriteOutput()
        {
            if (!string.IsNullOrEmpty(output1))
            {
                if (!string.IsNullOrEmpty(output1Path))
                {
                    System.IO.File.WriteAllTextAsync(output1Path, output1);
                }
                else
                {
                    throw new Exception("no input path");
                }
            }

            if (!string.IsNullOrEmpty(output2))
            {
                if (!string.IsNullOrEmpty(output2Path))
                {
                    System.IO.File.WriteAllTextAsync(output2Path, output2);
                }
                else
                {
                    throw new Exception("no input path");
                }
            }
        }
    }
}
