﻿using System;
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
            int year = Convert.ToInt32(MainWindow1.SelectorYear.Text);
            int day = 01;

            switch (year)
            {
                case 2021:
                    {
                        switch (day)
                        {
                            case 01:
                                puzzle = new Day01();
                                puzzle.Solve();
                                break;
                           
                        }
                    }
                    break;
                case 2020:
                    break;
            }            
        }
    }
}
