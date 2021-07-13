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
using Gavilya.SDK.RAWG;
using Gavilya.Windows;
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

namespace Gavilya.Pages
{
	/// <summary>
	/// Interaction logic for AddEditPage2.xaml
	/// </summary>
	public partial class AddEditPage2 : Page
	{
		internal AddGame AddGame { get; set; }
		internal EditGame EditGame { get; set; }

		internal List<Platform> Platforms { get; set; }
		internal List<Store> Stores { get; set; }
		internal string GameDescription { get; set; }
		internal int RAWGID { get; set; }

		bool isFromAdd;
		public AddEditPage2(AddGame addGame)
		{
			InitializeComponent();
			AddGame = addGame; // Set
			isFromAdd = true;
			Platforms = new();
			Stores = new();
			RAWGID = AddGame.RAWGID;
			InitUI();
		}

		public AddEditPage2(EditGame editGame)
		{
			InitializeComponent();
			EditGame = editGame; // Set
			isFromAdd = false;
			RAWGID = EditGame.RAWGID;
			InitUI();
		}

		private void InitUI()
		{
			if (RAWGID != -1)
			{
				AssociateTxt.Text = Properties.Resources.Associated; // Set
				AssociateIconTxt.Text = "\uE98E"; // Set
			}
			else
			{
				AssociateTxt.Text = Properties.Resources.NotAssociated; // Set
				AssociateIconTxt.Text = "\uE9D8"; // Set
			}
		}

		private void NextBtn_Click(object sender, RoutedEventArgs e)
		{
			if (isFromAdd)
			{
				Definitions.Games.Add(new()
				{
					Name = AddGame.GameName, // Set value
					Version = AddGame.GameVersion, // Set value
					Description = GameDescription, // Set value
					FileLocation = AddGame.GameLocation, // Set value
					IconFileLocation = AddGame.GameIconLocation, // Set value
					IsFavorite = false, // Set value
					RAWGID = RAWGID, // Set value
					LastTimePlayed = 0, // Set value
					TotalTimePlayed = 0, // Set value
					ProcessName = "", // Set value
					Platforms = (Platforms.Count == 0) ? new List<SDK.RAWG.Platform> { Definitions.DefaultPlatform } : Platforms, // Get platforms
					Stores = Stores
				});

				new GameSaver().Save(Definitions.Games); // Save
				Global.ReloadAllPages(); // Refresh UI

				AddGame.Close();
			}
			else
			{
				EditGame.Close();
			}
			try
			{
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, Properties.Resources.MainWindowTitle, MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void CancelBtn_Click(object sender, RoutedEventArgs e)
		{
			if (isFromAdd)
			{
				AddGame.Close();
			}
			else
			{
				EditGame.Close();
			}
		}

		private void AssociateBtn_Click(object sender, RoutedEventArgs e)
		{
			new SearchGameCover(this, GameAssociationActions.Associate).Show();
		}
	}
}
