using System;
using System.IO;
using System.Runtime.CompilerServices;

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

            if (File.Exists(folderPath + @"\Input.txt"))
            {
                input = System.IO.File.ReadAllText(folderPath + @"\Input.txt");
            }
            else
            {
                throw new Exception("no input file");
            }
        }

        public void WriteOutput([CallerFilePath] string sourceFilePath = "")
        {

            string folderPath = new FileInfo(fileName: sourceFilePath).Directory?.FullName ?? "";

            if (!string.IsNullOrEmpty(output1))
            {
                File.WriteAllTextAsync(folderPath + @"\Output1.txt", output1);
            }
            else
            {
                throw new Exception("output1 not set");
            }

            if (!string.IsNullOrEmpty(output2))
            {
                File.WriteAllTextAsync(folderPath + @"\Output2.txt", output2);                
            }            
        }
    }
}
