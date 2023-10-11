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
    /// Interaction logic for Admin_Landing_Page.xaml
    /// </summary>
    public partial class Admin_Landing_Page : Window
    {
        public Admin_Landing_Page()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow n = new MainWindow();
            n.Show();
            this.Close();
        }
    }
}
