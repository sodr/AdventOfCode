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
		IPuzzle? puzzle = null;
		int year, day;

		void Run()
        {
			year = Convert.ToInt32(MainWindow1.SelectorYear.Text);
			day = Convert.ToInt32(MainWindow1.SelectorDay.Text);

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

							case 03:
								puzzle = new Year_2021.Day03();
								break;
						}
						break;

					case 2020:
						break;
				}

				puzzle?.Solve();

			}
			catch (Exception ex)
			{
				Debug.Fail(ex.Message);
			}
		}

		public MainWindow()
		{
			InitializeComponent();
			Run();
		}

		private void ButtonRun_Click(object sender, RoutedEventArgs e)
		{
			Run();  
		}

	}
}
