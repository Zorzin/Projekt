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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for DriverAddWindow.xaml
    /// </summary>
    public partial class DriverAddWindow : Window
    {
        public DriverAddWindow()
        {
            InitializeComponent();
            Commands.BindCommandsToWindow(this);
        }
        private void AddButton(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Close();

        }
    }
}