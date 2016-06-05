using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        }
        public static RoutedUICommand ButtonCommand { get; set; }
        public static RoutedUICommand BackButtonCommand { get; set; }

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
            List[e.Source].Invoke();
        }

        public static void ButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public static void BindCommandsToWindow(Window window)
        {
            window.CommandBindings.Add(
                new CommandBinding(BackButtonCommand, BackButtonCommandExecuted, BackButtonCommandCanExecute));
            window.CommandBindings.Add(new CommandBinding(ButtonCommand, ButtonCommandExecuted,
                ButtonCommandCanExecute));
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

        public static int DriverAddFunction()
        {
            var driverAddWindow = new DriverAddWindow();
            driverAddWindow.Show();
            return 1;
        }
        public static int BusStopAddFunction()
        {
            //var busStopAddWindow = new BusStopAddWindow();
            //busStopAddWindow.Show();
            return 1;
        }

        public static int BusAddFunction()
        {
            var busAddWindow = new BusAddWindow();
            busAddWindow.Show();
            return 1;
        }

        public static int ActualTrackAddFunction()
        {
            var actualTrackAddWindow = new ActualTrackAddWindow();
            actualTrackAddWindow.Show();
            return 1;
        }

        public static int LineAddFunction()
        {
            var lineAddWindow = new LineAddWindow();
            lineAddWindow.Show();
            return 1;
        }
    }
}