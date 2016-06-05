using System;
using System.Collections.Generic;
using System.IO;
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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for DriverListPage.xaml
    /// </summary>
    public partial class DriverListPage : Page
    {
        public DriverListPage()
        {
            InitializeComponent();
            Commands.List [AddButton] = Commands.DriverAddFunction;
            ListBox.ItemsSource = Lists.Drivers;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            DbConnect db = new DbConnect();
            Driver driver = (Driver)ListBox.SelectedItem;
            db.Delete("driver", driver.Id.ToString());
            Lists.Drivers.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.OpenFileDialog();
            var result = dialog.ShowDialog();
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK:
                    PathTextBox.Text = dialog.FileName.Substring(dialog.FileName.LastIndexOf("\\")+1);
                    if (!File.Exists(Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                                Path.GetFileName(dialog.FileName))))
                    {
                        File.Copy(dialog.FileName,
                            Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                                Path.GetFileName(dialog.FileName)));
                    }
                    PathTextBox.Focus();
                    break;
                default:
                    break;
            }
        }
    }
}
