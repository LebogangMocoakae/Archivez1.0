using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows;

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for View_Records.xaml
    /// </summary>
    public partial class View_Records : Window
    {

        static string connectionString = "Server=tcp:kamvaarchztest.database.windows.net,1433;Initial Catalog=TestDatabase;Persist Security Info=False;User ID=lebogang@kamvacloud.co.za;Password=#Kamo13137;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Authentication=\"Active Directory Password\";";
        SqlConnection connection = new SqlConnection(connectionString);
        string radioInfo = "";
        public View_Records()
        {
            InitializeComponent();

            connection.Open();
        }



        private void Search_Click(object sender, RoutedEventArgs e)
        {
            
            if(radioInfo == "ID NUMBER")
            {
                string id = txtBox.Text;
                string value = "";
                string selectQuery = "SELECT * FROM Patients WHERE PatientID = @PatientID";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@PatientID", id);

               // SqlDataReader reader = selectCommand.ExecuteReader();

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                sqlDataAdapter.Fill(dataTable);
                datagrid.ItemsSource = dataTable.DefaultView;

                //while (reader.Read())
                //{
                //    // Access data fields by column name or index
                //    //value = reader["VisitReason"].ToString();
                   
                //    sqlDataAdapter.Fill(dataTable);
                //    // ... and so on
                //}


                MessageBox.Show("ID Search: " + id);
                MessageBox.Show(value);
            }

            if(radioInfo == "FIRSTNAME")
            {
                string firstName = txtBox.Text;
                string selectQuery = "SELECT * FROM TeastDatabase WHERE FirstName = @FirstName";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);



                selectCommand.Parameters.AddWithValue("@Firstname", firstName);

                MessageBox.Show("Firstname Search: " + firstName);
            }

            if(radioInfo == "SURNAME")
            {
                string surname = txtBox.Text;
                string selectQuery = "SELECT * FROM TeastDatabase WHERE surname = @surname";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);



                selectCommand.Parameters.AddWithValue("@surname", surname);

                MessageBox.Show("surname Search: " + surname);
            }


          
        }

        private void CBID_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == CBID)
            {
                radioInfo = CBID.Content.ToString();
                
                CBFirstName.IsChecked = false;
                CBSurname.IsChecked = false;
            }
           
            
        }

        private void CBFirstName_Checked(object sender, RoutedEventArgs e)
        {
             if (sender == CBFirstName)
            {
                radioInfo = CBFirstName.Content.ToString();

                CBID.IsChecked = false;
                CBSurname.IsChecked = false;
            }
        }

        private void CBSurname_Checked(object sender, RoutedEventArgs e)
        {
            if (sender == CBSurname)
            {
                radioInfo = CBSurname.Content.ToString();

                CBID.IsChecked = false;
                CBFirstName.IsChecked = false;
            }
        }
    }
}
