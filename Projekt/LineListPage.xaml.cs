using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for LineListPage.xaml
    /// </summary>
    public partial class LineListPage : Page
    {
        public LineListPage()
        {
            View.Filter = null;
            InitializeComponent();
            Commands.List[AddButton] = Commands.LineAddFunction;
            ListBox.ItemsSource = Lists.Lines;
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Line line = (Line) ListBox.SelectedItem;
            bool firsttrack = false;
            int trackscount = Lists.ActualTracks.Count;
            for(int i=trackscount-1;i>=0;i--)
            {
                var actualTrack = Lists.ActualTracks[i];
                if (actualTrack.Line == line )
                {
                    if (!firsttrack)
                    {
                        firsttrack = true;
                        MessageBoxButton mbb = MessageBoxButton.YesNo;
                        MessageBoxResult dr = MessageBox.Show("Usuwana linia ma zaplanowane kursy, usunąć wraz z kursami?", "Usunąć?", mbb);
                        if (dr == MessageBoxResult.Yes)
                        {
                            RemoveJoining(actualTrack,line);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        RemoveJoining(actualTrack, line);
                    }
                }
            }
            DbConnect db = new DbConnect();
            db.Delete("line", line.Number.ToString());
            Lists.Lines.RemoveAt(ListBox.SelectedIndex);
            ListBox.SelectedIndex = ListBox.Items.Count - 1;
        }

        private void RemoveJoining(ActualTrack track, Line line)
        {
            if (track.Driver != null)
            {
                if (track.Driver.Actualbus!=null)
                {
                    if (track.Driver.Actualbus.Actualdriver!=null)
                    {
                        if (track.Driver.Actualbus.Actualline!=null)
                        {
                            track.Driver.Actualbus.Actualline = null;
                        }
                        track.Driver.Actualbus.Actualdriver = null;
                    }
                    track.Driver.Actualbus = null;
                }
                track.Driver = null;
            }
            track.Line = null;
            Lists.ActualTracks.Remove(track);
        }

        private class SortByLine : System.Collections.IComparer
        {
            public int Compare(object x, object y)
            {
                Line line1 = (Line) x;
                Line line2 = (Line) y;
                return line1.Number.CompareTo(line2.Number);
            }
        }

        private ListCollectionView View
        {
            get
            {
                return (ListCollectionView)CollectionViewSource.GetDefaultView(Lists.Lines);
            }
        }

        private void Filter(object sender, RoutedEventArgs e)
        {
            var number = Int32.Parse(linefiltertxt.Text);
            View.Filter = delegate (object item)
            {
                var line = item as Line;
                if (line != null)
                {
                    return line.Number == number;
                }
                return false;
            };
        }

        private void FilterNone(object sender, RoutedEventArgs e)
        {
            View.Filter = null;
        }

        private void SortNone(object sender, RoutedEventArgs e)
        {
            View.SortDescriptions.Clear();
            View.CustomSort = null;
        }

        private void SortLine(object sender, RoutedEventArgs e)
        {
            View.CustomSort = new SortByLine();
        }

        private void GroupNone(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
        }

        private void GroupByFirstBusStop(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Firststop"));
        }

        private void GroupByLastBusStop(object sender, RoutedEventArgs e)
        {
            View.GroupDescriptions.Clear();
            View.GroupDescriptions.Add(new PropertyGroupDescription("Laststop"));
        }
    }
}
