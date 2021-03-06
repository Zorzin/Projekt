﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Projekt
{
    internal class Commands
    {
        public static RoutedEventArgs Source;
        public static Dictionary<object, Func<int>> List;

        static Commands()
        {
            ButtonCommand = new RoutedUICommand("Edit existing record", "edit", typeof (Commands));
            BackButtonCommand = new RoutedUICommand("Return to main window", "return", typeof (Commands));
            AddDriverButtonCommand = new RoutedUICommand("Show new window to add driver", "add", typeof(Commands));
            AddBusButtonCommand = new RoutedUICommand("Show new window to add bus", "add", typeof(Commands));
            AddBusStopButtonCommand = new RoutedUICommand("Show new window to add bus stop", "add", typeof(Commands));
            AddLineButtonCommand = new RoutedUICommand("Show new window to add line", "add", typeof(Commands));
            AddActualTrackButtonCommand = new RoutedUICommand("Show new window to add track", "add", typeof(Commands));
        }
        public static RoutedUICommand ButtonCommand { get; set; }
        public static RoutedUICommand BackButtonCommand { get; set; }
        public static RoutedUICommand AddDriverButtonCommand { get; set; }
        public static RoutedUICommand AddBusButtonCommand { get; set; }
        public static RoutedUICommand AddBusStopButtonCommand { get; set; }
        public static RoutedUICommand AddLineButtonCommand { get; set; }
        public static RoutedUICommand AddActualTrackButtonCommand { get; set; }

        public static void BindCommandsToWindow(Window window)
        {
            window.CommandBindings.Add(new CommandBinding(ButtonCommand, ButtonCommandExecuted,
                ButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(BackButtonCommand, BackButtonCommandExecuted,
                BackButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(AddBusButtonCommand, AddBusButtonCommandExecuted,
                AddBusButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(AddLineButtonCommand, AddLineButtonCommandExecuted,
                AddLineButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(AddBusStopButtonCommand, AddBusStopButtonCommandExecuted,
                AddBusStopButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(AddDriverButtonCommand, AddDriverButtonCommandExecuted,
                AddDriverButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(AddActualTrackButtonCommand, AddActualTrackButtonCommandExecuted,
                AddActualTrackButtonCommandCanExecute));
        }

        public static void AddDriverButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var adddriver = new DriverAddWindow();
            adddriver.ShowDialog();
        }

        public static void AddDriverButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public static void AddActualTrackButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var addtrack = new AddActualTrackWindow();
            addtrack.ShowDialog();
        }

        public static void AddActualTrackButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static void AddBusButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var addbus = new BusAddWindow();
            addbus.ShowDialog();
        }

        public static void AddBusButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static void AddBusStopButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var busstop = new BusStopAddWindow();
            busstop.ShowDialog();
        }

        public static void AddBusStopButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static void AddLineButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var addline = new LineAddWindow();
            addline.ShowDialog();
        }

        public static void AddLineButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public static void BackButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var exist = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            exist.Close();
        }

        public static void BackButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public static void ButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            /**
            foreach (var butn in List)
            {
                Button button = butn.Key as Button;
                var bc = new BrushConverter();
                button.Background = (Brush)bc.ConvertFrom("#EEEEEEEE");
            }
            Button btn = e.Source as Button;
            
            btn.Background = Brushes.Red;
            */        
            List [e.Source].Invoke();
        }

        public static void ButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        
        public static int DriverFunction()
        {
            var driverListPage = new DriverListPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(driverListPage);
            return 1;
        }

        public static int BusStopFunction()
        {
            var busStopListPage = new BusStopListPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(busStopListPage);
            return 1;
        }

        public static int BusFunction()
        {
            var busListPage = new BusListPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(busListPage);
            return 1;
        }

        public static int ActualTrackFunction()
        {
            var actualTrackPage = new ActualTrackPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(actualTrackPage);
            return 1;
        }

        public static int LineFunction()
        {
            var lineListPage = new LineListPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(lineListPage);
            return 1;
        }

        public static int StartPageFunction()
        {
            var startpage = new StarPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(startpage);
            return 1;
        }

        public static int SearchButtonFunction()
        {
            SearchPage searchPage = new SearchPage();
            var mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(searchPage);
            return 1;
        }
    }
}