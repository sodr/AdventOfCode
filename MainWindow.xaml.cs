using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Advent_of_Code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonRun_Click(object sender, RoutedEventArgs e)
        {
            IPuzzle puzzle;
            string year = MainWindow1.SelectorYear.Text;
            string day = "01";     
            string basePath = @"S:\dev\github\sodr\AdventOfCode\Advent of Code";

            puzzle = new Day01
            {
                inputPath = @$"{basePath}\Aoc\{year}\{day}\Input.txt",
                output1Path = @$"{basePath}\Aoc\{year}\{day}\Output1.txt",
                output2Path = @$"{basePath}\Aoc\{year}\{day}\Output2.txt",
            };


            puzzle.Main();

            bool yo = false;
        }
    }
}
