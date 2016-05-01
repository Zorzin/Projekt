using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Projekt
{
    class Commands
    {
        public static RoutedUICommand ButtonCommand { get; set; }
        public static RoutedUICommand BackButtonCommand { get; set; }
        static Commands()
        {
            ButtonCommand = new RoutedUICommand("Edit/Add existing record", "edit/add", typeof (Commands));
            BackButtonCommand = new RoutedUICommand("Return to main window", "return", typeof(Commands));
        }

        public static void BackButtonCommandExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var exist = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.IsActive);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            if (exist != null)
            {
                exist.Close();
            }
        }

        public static void BackButtonCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public static void BindCommandsToWindow(Window window)
        {
            window.CommandBindings.Add(
                new CommandBinding(BackButtonCommand, BackButtonCommandExecuted, BackButtonCommandCanExecute));
        }
    }
}
