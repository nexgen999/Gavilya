﻿/*
MIT License

Copyright (c) Léo Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE. 
*/
using Gavilya.Classes;
using Gavilya.UserControls;
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
using System.Windows.Shapes;

namespace Gavilya.Windows
{
	/// <summary>
	/// Interaction logic for SelectImportGamesWindow.xaml
	/// </summary>
	public partial class SelectImportGamesWindow : Window
	{
		public SelectImportGamesWindow()
		{
			InitializeComponent();
			InitUI(); // Load the UI
		}

		private void InitUI()
		{
			if (Definitions.Games.Count > 0)
			{
				for (int i = 0; i < Definitions.Games.Count; i++)
				{
					GamePresenter.Children.Add(new ImportGameItem(Definitions.Games[i])); // Add item
				}
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			WindowState = WindowState.Minimized; // Set
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Close(); // Close the window
		}

		private void FinishBtn_Click(object sender, RoutedEventArgs e)
		{
			if (GamePresenter.Children.Count > 0)
			{
				List<GameInfo> gameInfos = new();

				for (int i = 0; i < GamePresenter.Children.Count; i++)
				{
					var game = (ImportGameItem)GamePresenter.Children[i];
					if (game.SelectCheckBox.IsChecked.Value)
					{
						gameInfos.Add(game.GameInfo); // Add 
					}
				}

				Definitions.Games = gameInfos; // Set
				new GameSaver().Save(Definitions.Games); // Save changes
			}

			Global.ReloadAllPages(); // Refresh
			Close(); // Close the window
		}
	}
}
