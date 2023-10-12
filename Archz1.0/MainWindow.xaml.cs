using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using Microsoft.Data.SqlClient;

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
            else
            {

                string connectionString = "Server=tcp:kamvaarchztest.database.windows.net,1433;Initial Catalog=AccessUsers;Persist Security Info=False;User ID=lebogang@kamvacloud.co.za;Password=#Kamo13137;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";

                //string connectionString = "Server=kamvaarchztest.database.windows.net;Database=AccessUsers;User Id=Lebogang@kamvacloud.co.za@kamvaarchztest;Password=#Kamo1377;Trusted_Connection=True;Connection Timeout=60;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                  

                MessageBox.Show("Connection to SQL Server is open.");

                //MessageBox.Show("User Name: " + user + "\nPassword: " + pass);

                //Admin_Landing_Page n = new Admin_Landing_Page();
                //n.Show();
                //this.Close();
            }



            }

        }
    }


