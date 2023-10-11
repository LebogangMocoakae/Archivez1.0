using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
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

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public string user = "", pass = "";

        public MainWindow()
        {
            InitializeComponent();
        }

       

       

        private void userName_TextChanged(object sender, TextChangedEventArgs e)
        {
            user = userName.Text;
        }
        private void password_TextChanged(object sender, TextChangedEventArgs e)
        {
            pass=password.Text;
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if(user == string.Empty || pass == string.Empty)
            {
                MessageBox.Show("Please fill in all the boxes!!");
            }
            else
            {
                MessageBox.Show("User Name: " + user + "\nPassword: " + pass);
                 
                Admin_Landing_Page n = new Admin_Landing_Page();
                n.Show();
                this.Close();
            }            
            

            
        }

    }
}
