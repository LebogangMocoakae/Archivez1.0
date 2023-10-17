using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Diagnostics;

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for Edit_Record.xaml
    /// </summary>
    public partial class Edit_Record : Window
    {
       static string connectionString = "Server=tcp:kamvaarchztest.database.windows.net,1433;Initial Catalog=TestDatabase;Persist Security Info=False;User ID=lebogang@kamvacloud.co.za;Password=#Kamo13137;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";
         SqlConnection connection = new SqlConnection(connectionString);

        public Edit_Record()
        {
            InitializeComponent();
           
            connection.Open();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = txtIDSearch.Text;
           

            string searchQuery = "SELECT * FROM Patients WHERE PatientID = @PatientID";
            SqlCommand searchCommand = new SqlCommand(searchQuery, connection);
            searchCommand.Parameters.AddWithValue("PatientID", id);

            SqlDataReader reader = searchCommand.ExecuteReader();
            if(reader.Read()) 
            {
                MessageBox.Show(reader["surname"].ToString());

                txtName.Text = (reader["FirstName"].ToString());
                txtSurname.Text= (reader["surname"].ToString());
                txtID.Text = (reader["PatientID"].ToString());
                txtGender.Text = (reader["Gender"].ToString());
                txtRace.Text = (reader["Race"].ToString());
                txtVisitReason.Text=(reader["VisitReason"].ToString());
            }


        }

        private void SubmitButton_Click_1(object sender, RoutedEventArgs e)
        {
            string updateQuery = "UPDATE Patients SET PatientID=@PatientID, FirstName=@FirstName, surname=@surname,Gender=@Gender,Race=@Race,VisitReason=@VisitReason" +" WHERE PatientID=@PatientID";

            string id= txtID.Text;
            string firstName = txtName.Text;
            string surname = txtSurname.Text;
            string gender = txtGender.Text;
            string race = txtRace.Text;
            string visitReason = txtVisitReason.Text;

            SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
            updateCommand.Connection = connection;
            updateCommand.Parameters.AddWithValue("@PatientID", id);
            updateCommand.Parameters.AddWithValue("@FirstName", firstName);
            updateCommand.Parameters.AddWithValue("@surname", surname);
            updateCommand.Parameters.AddWithValue("@Gender", gender);
            updateCommand.Parameters.AddWithValue("@Race", race);
            updateCommand.Parameters.AddWithValue("@VisitReason", visitReason);

            updateCommand.ExecuteNonQuery();
            MessageBox.Show("done");
        }
    }
}
