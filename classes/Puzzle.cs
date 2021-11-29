using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Advent_of_Code
{
    interface IPuzzle
    {
        internal string Part1();
        internal string Part2();
        void Solve();
    }

    abstract class Puzzle : IPuzzle
    {   
        
        public abstract string Part1();

        public virtual string Part2()
        {
            return String.Empty;
        }

        public void Solve()
        {
            ReadInput();
            output1 = Part1();
            output2 = Part2();
            WriteOutput();
        }

        internal string? FolderPath;
        internal string? input;
        private string? output1;
        private string? output2;

        internal void AutoSetFolderPath([CallerFilePath] string sourceFilePath = "")
        {
            FolderPath = new FileInfo(fileName: sourceFilePath).Directory?.FullName ?? ""; ;
        }

        public void ReadInput([CallerFilePath] string sourceFilePath = "")
        {            
            if (File.Exists(FolderPath + @"\Input.txt"))
            {
                input = System.IO.File.ReadAllText(FolderPath + @"\Input.txt");
            }
            else
            {
                throw new Exception("no input file");
            }
        }

        public void WriteOutput([CallerFilePath] string sourceFilePath = "")
        {
            if (!string.IsNullOrEmpty(output1))
            {
                File.WriteAllTextAsync(FolderPath + @"\Output1.txt", output1);
            }
            else
            {
                throw new Exception("output1 not set");
            }

            if (!string.IsNullOrEmpty(output2))
            {
                File.WriteAllTextAsync(FolderPath + @"\Output2.txt", output2);                
            }            
        }
    }
}
