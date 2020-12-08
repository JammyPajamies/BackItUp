﻿using BackItUp.ViewModels;
using System;
using System.Windows;

namespace BackItUp.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new BackupInfoViewModel();
            this.DataContext = viewModel;
            this.Show();
        }

        private void stateChanged(object sender, EventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
    }
}