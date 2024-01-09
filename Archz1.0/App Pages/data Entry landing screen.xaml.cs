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
    /// Interaction logic for data_Entry_landing_screen.xaml
    /// </summary>
    public partial class data_Entry_landing_screen : Window
    {
        public data_Entry_landing_screen(string username)
        {
            InitializeComponent();

            MessageBox.Show("User logged in: " + username);
        }
    }
}
