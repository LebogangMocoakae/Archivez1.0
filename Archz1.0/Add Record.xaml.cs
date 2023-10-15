﻿using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
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
        public string connectionString = "Server=tcp:kamvaarchztest.database.windows.net,1433;Initial Catalog=TestDatabase;Persist Security Info=False;User ID=lebogang@kamvacloud.co.za;Password=#Kamo13137;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";
        
        public Add_Record(string user, string database)
        {
            InitializeComponent();
            LoginUser.Text = "Logged in user: "+ user;
            selected_database.Text = "Selected Database: " + database;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtID.Text == string.Empty || txtName.Text == string.Empty || txtSurname.Text == string.Empty || txtRace.Text == string.Empty)
            {
                MessageBox.Show("please enter all fields!!!");
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Patients (PatientID, FirstName, surname,Gender,Race,VisitReason) VALUES (@PatientID, @FirstName, @surname, @DataOfBirth, @Gender, @Race, @VisitReason)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    { 

                    command.Parameters.AddWithValue("@PatientID", txtID.Text); // Replace with actual data
                    command.Parameters.AddWithValue("@FirstName", txtName.Text); // Replace with actual data

                    command.Parameters.AddWithValue("@surname", txtSurname.Text);// Replace with actual data
                    command.Parameters.AddWithValue("@Gender", txtGender.Text);

                    command.Parameters.AddWithValue("@Race", txtRace.Text); // Replace with actual data
                    command.Parameters.AddWithValue("@VisitReason", txtVisitReason);
                        MessageBox.Show("Complete");



                    }

                    

                }
            }
        }
    }
}