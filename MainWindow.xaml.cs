using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            IPuzzle? puzzle = null;

            int year = Convert.ToInt32(MainWindow1.SelectorYear.Text);
            int day = Convert.ToInt32(MainWindow1.SelectorDay.Text);

            try
            {
                switch (year)
                {
                    case 2021:
                        
                        switch (day)
                        {
                            case 01:
                                puzzle = new Year_2021.Day01();
                                break;
                            case 02:
                                puzzle = new Year_2021.Day02();
                                break;
                        }                        
                        break;

                    case 2020:
                        break;
                }

                if (puzzle != null)
                {
                    puzzle.Solve();
                }
                
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
            }
                       
        }

    }
}
