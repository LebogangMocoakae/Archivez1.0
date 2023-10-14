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
using System.Text.RegularExpressions;

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
            pass = password.Text;
        }


        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {


            if (user == string.Empty || pass == string.Empty)
            {
                MessageBox.Show("Please fill in all the boxes!!");
            }
            else if (user != string.Empty && HasNumbers(user))
            {
                MessageBox.Show("Fix User Name to have Letter's only ");
            }

            else
            {
                MessageBox.Show("User Name: " + user + "\nPassword: " + pass);

                Admin_Landing_Page n = new Admin_Landing_Page();
                n.Show();
                this.Close();

            }

        }
        /*bool hasnumbers(string text)
        {
            foreach (char c in text)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }

            }
            return true;

        }
        */
        bool HasNumbers(string text)
        {
            bool isIntString = text.Any(char.IsDigit);
            return isIntString;
        }
        /*bool Hasnumbers_only(string text)
        {
            bool isIntString = text.all(char.IsDigit);
            return isIntString;
        }
        */


    }
}
