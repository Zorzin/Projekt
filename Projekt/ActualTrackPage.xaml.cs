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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for ActualTrackPage.xaml
    /// </summary>
    public partial class ActualTrackPage : Page
    {
        public ActualTrackPage()
        {
            InitializeComponent();
            Commands.List[AddButton] = Commands.ActualTrackAddFunction;
            ListBox.ItemsSource = Lists.ActualTracks;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var actualTrack = (ActualTrack) ListBox.SelectedItem;
            if (actualTrack.Driver.Actualbus != null)
            {
                MessageBoxButton mbb = MessageBoxButton.YesNo;
                MessageBoxResult dr = MessageBox.Show("Usuwany kurs jest aktualnie na trasie, usunąć?", "Usunąć?", mbb);
                if (dr == MessageBoxResult.Yes)
                {
                    actualTrack.Driver.Actualbus.Actualdriver = null;
                    actualTrack.Driver.Actualbus.Actualline = null;
                    actualTrack.Driver.Actualbus = null;
                }
                else
                {
                    return;
                }
            }
            actualTrack.Driver = null;
            actualTrack.Line = null;
            Lists.ActualTracks.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }
    }
}
