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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace Xalyus_Updater
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient client = new WebClient(); // Webclient
        public MainWindow()
        {
            InitializeComponent();
            InitText(); // Load the text
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InitText()
        {
            switch (Thread.CurrentThread.CurrentUICulture.Name) // In each case for the language name
            {
                case "fr-FR": // If the language is French
                    TitleTxt.Text = "Gavilya"; // Title
                    DescriptionTxt.Text = "Gavilya est un simple lanceur de jeu."; // Description
                    break;
                case "en-US": // If the language is English
                    TitleTxt.Text = "Gavilya"; // Title
                    DescriptionTxt.Text = "Gavilya is a simple a game launcher."; // Description
                    break;

                default: // Default
                    TitleTxt.Text = "Gavilya"; // Title
                    DescriptionTxt.Text = "Gavilya is a simple a game launcher."; // Description
                    break;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebClient linkDownloader = new WebClient(); // Link downloader
            string link = linkDownloader.DownloadString(Global.ZIPLink); // Download the link

            client.DownloadProgressChanged += Client_DownloadProgressChanged; // Register event
            client.DownloadFileCompleted += Client_DownloadFileCompleted; // Register event

            if (!string.IsNullOrEmpty(link))
            {
                Thread thread = new Thread(() =>
                {
                    Uri uri = new Uri(link);
                    client.DownloadFileAsync(uri, Global.Directory); // Download
                });
                thread.Start();
            }
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                Close();
            });
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                double receive = double.Parse(e.BytesReceived.ToString()); // Total downloaded
                double total = double.Parse(e.TotalBytesToReceive.ToString()); // Total
                double percentage = receive / total * 100; // Calculate the percentage
                ProgressTxt.Text = $"{string.Format("{0:0.##}", percentage)}%"; // Show the progress
                Pgb.Value = int.Parse(Math.Truncate(percentage).ToString()); // Update the progress bar value
            });
        }
    }
}
