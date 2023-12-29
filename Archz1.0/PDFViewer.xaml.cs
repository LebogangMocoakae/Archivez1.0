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

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for PDFViewer.xaml
    /// </summary>
    public partial class PDFViewer : Window
    {
        public PDFViewer(string uri)
        {
            InitializeComponent();
            System.Uri link = new Uri(uri);

            webView.Source = link;
        }
    }
}
