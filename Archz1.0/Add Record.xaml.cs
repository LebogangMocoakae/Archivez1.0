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
    /// Interaction logic for Add_Record.xaml
    /// </summary>
    public partial class Add_Record : Window
    {
        public Add_Record(string user, string database)
        {
            InitializeComponent();
            LoginUser.Text = "Logged in user: "+ user;
            selected_database.Text = "Selected Database: " + database;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
