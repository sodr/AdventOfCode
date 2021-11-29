using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Advent_of_Code
{
    interface IPuzzle
    {
        void Solve();
    }

    abstract class Puzzle : IPuzzle
    {   
        public abstract void Solve();

        internal string? input;
        internal string? output1;
        internal string? output2;

        public void ReadInput([CallerFilePath] string sourceFilePath = "")
        {
            string folderPath = new FileInfo(fileName: sourceFilePath).Directory?.FullName ?? "";

            if (!string.IsNullOrEmpty(folderPath))
            {
                input = System.IO.File.ReadAllText(folderPath + @"\Input.txt");
            }
            else
            {
                throw new Exception("no input path");
            }
        }

        public void WriteOutput([CallerFilePath] string sourceFilePath = "")
        {

            string folderPath = new FileInfo(fileName: sourceFilePath).Directory?.FullName ?? "";

            if (!string.IsNullOrEmpty(output1))
            {
                if (!string.IsNullOrEmpty(folderPath))
                {
                    System.IO.File.WriteAllTextAsync(folderPath + @"\Output1.txt", output1);
                }
                else
                {
                    throw new Exception("no input path");
                }
            }

            if (!string.IsNullOrEmpty(output2))
            {
                if (!string.IsNullOrEmpty(folderPath))
                {
                    System.IO.File.WriteAllTextAsync(folderPath + @"\Output2.txt", output2);
                }
                else
                {
                    throw new Exception("no input path");
                }
            }
        }
    }
}
