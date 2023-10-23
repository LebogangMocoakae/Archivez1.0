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
    /// Interaction logic for Loading_window.xaml
    /// </summary>
    public partial class Loading_window : Window
    {
        public Loading_window()
        {
            InitializeComponent();
            bar.Visibility = Visibility.Visible; // Show the loading bar


        }
    }
}
