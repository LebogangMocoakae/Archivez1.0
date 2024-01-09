using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
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
using Microsoft.Identity.Client;
using Archz1._0.App_Pages;

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for Admin_Landing_Page.xaml
    /// </summary>
    public partial class Admin_Landing_Page : Window
    {
        strings strings = new strings();
        string connectionStringDatabases;
        string passuser;
        string selectedDatabaseName;



        public Admin_Landing_Page(string username)
        {
            InitializeComponent();
            connectionStringDatabases = strings.connectionStringDatabases;
            LoginUser.Text = "Logged in User: " + username;
            returnuserName(username);

       
            string loggedinUser=username;


            using (SqlConnection connection = new SqlConnection(connectionStringDatabases))
            {
                try
                {
                    connection.Open();
                    DataTable databases = connection.GetSchema("Databases");

                    // Clear the ComboBox to avoid duplicates
                    dropMenu.Items.Clear();

                    // Populate the ComboBox with database names
                    foreach (DataRow row in databases.Rows)
                    {
                        string databaseName = row["database_name"].ToString();
                        dropMenu.Items.Add(databaseName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error:here " + ex.Message);
                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow n = new MainWindow();
            n.Show();
            this.Close();
        }

        private void dropMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            MessageBox.Show(dropMenu.SelectedItem.ToString());
            selectedDatabaseName = dropMenu.SelectedItem.ToString();

        }

        public void returnuserName(string name)
        {
            passuser = name;
            
        }

        private void btnAddRecord_Click(object sender, RoutedEventArgs e)
        {


            Add_Record add_Record = new Add_Record(passuser,selectedDatabaseName);
            add_Record.Show();
            
        }

        private void btnEditRecord_Click(object sender, RoutedEventArgs e)
        {
            Edit_Record n = new Edit_Record();
            n.Show();
        }

        private void btnViewRecord_Click(object sender, RoutedEventArgs e)
        {
            View_Records n = new View_Records();
            n.Show();
        }
    }
}
