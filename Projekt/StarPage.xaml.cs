using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using Path = System.IO.Path;
using System.Windows.Forms;
using System.Drawing;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for StarPage.xaml
    /// </summary>
    public partial class StarPage : Page
    {
        public StarPage()
        {
            InitializeComponent();
            Uri uri = new Uri(Path.Combine(Path.Combine(Environment.CurrentDirectory, "images"),
                    Path.GetFileName("bus.jpg")));
            BitmapImage imagebitmap = new BitmapImage(uri);
            MainImage.Source = imagebitmap;
        }
    }
}
