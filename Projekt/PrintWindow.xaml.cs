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
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for PrintWindow.xaml
    /// </summary>
    public partial class PrintWindow : Window
    {
        public PrintWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if ((bool) printDialog.ShowDialog().GetValueOrDefault())
            {
                int pageMargin = 20;
                Size printSize = new Size(printDialog.PrintableAreaWidth - pageMargin * 2, printDialog.PrintableAreaHeight - 20);
                mainGrid.Measure(printSize);
                mainGrid.Arrange(new Rect(pageMargin,pageMargin,printSize.Width,printSize.Height));
                printDialog.PrintVisual(mainGrid, "Wydruk");
            }
        }
    }
}
