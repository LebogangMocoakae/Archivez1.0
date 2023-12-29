﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Input;

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        strings strings = new strings();

        
        public string user = "", pass = "";

        public string databaseName = "";
        public string databasePassword = "", user_type = "";


        public string connectionString;

        //string connectionString = "Server=kamvaarchztest.database.windows.net;Database=AccessUsers;User Id=Lebogang@kamvacloud.co.za@kamvaarchztest;Password=#Kamo1377;Trusted_Connection=True;Connection Timeout=60;";
       

        public MainWindow()
        {
            InitializeComponent();
            connectionString = strings.connectionString;
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
                string usernameQuery = "SELECT Username FROM users where Username = @user";
                string passwordQuery = "SELECT Password FROM users where Password = @pass";
                string userTypeQuery = "SELECT UserType FROM users where Username = @user";
                SqlConnection connection = new SqlConnection(connectionString);

                Loading_window loadingWindow = new Loading_window();
                loadingWindow.Owner = this; // Set the owner to the main window
                loadingWindow.Show();

                connection.Open();



                SqlCommand command = new SqlCommand(usernameQuery, connection);


                // Add a parameter to the query
                command.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar, 50)); // Adjust the data type and size
                // Set the parameter value from user input
                command.Parameters["@user"].Value = user;

                SqlCommand passwordCommand = new SqlCommand(passwordQuery, connection);
                passwordCommand.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar, 50)); // Adjust the data type and size
                passwordCommand.Parameters["@pass"].Value = pass;

                SqlCommand userTypeCommand = new SqlCommand(userTypeQuery, connection);
                userTypeCommand.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar, 50)); // Adjust the data type and size
                userTypeCommand.Parameters["@user"].Value = user;



                SqlDataReader reader = command.ExecuteReader();
                SqlDataReader password_reader = passwordCommand.ExecuteReader();
                SqlDataReader usertype_reader = userTypeCommand.ExecuteReader();




                while (reader.Read())
                {
                    databaseName = reader.GetString(0);

                }
                while (password_reader.Read())
                {
                    databasePassword = password_reader.GetString(0);

                }
                while (usertype_reader.Read())
                {
                    user_type = usertype_reader.GetString(0);

                }



                if (databaseName.Equals(user))
                {
                    //MessageBox.Show("User found");
                    //MessageBox.Show("User type: " + user_type);

                    if (databasePassword.Equals(pass))
                    {
                        //  MessageBox.Show("Password correct");

                        if (user_type.Equals("Admin"))
                        {
                            Admin_Landing_Page n = new Admin_Landing_Page(databaseName);
                            loadingWindow.Close();
                            n.Show();
                            this.Close();
                        }
                        else
                        {

                            data_Entry_landing_screen n = new data_Entry_landing_screen(databaseName);
                            this.Close();
                            n.Show();

                        }




                    }
                    else
                    {
                        MessageBox.Show("Password incorrect");

                    }
                }
                else
                {
                    MessageBox.Show("User not found");
                }





                //MessageBox.Show("User Name: " + user + "\nPassword: " + pass);

                //Admin_Landing_Page n = new Admin_Landing_Page();
                //n.Show();
                //this.Close();
            }



        }

    }
}



