using Azure.Storage.Blobs;
using Microsoft.Data.SqlClient;
using System.Data;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Azure.Storage.Blobs.Models;
using System;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace Archz1._0
{
    /// <summary>
    /// Interaction logic for View_Records.xaml
    /// </summary>
    public partial class View_Records : Window
    {

        strings strings = new strings();
        string connectionString;




        string radioInfo = "";
        string userID = "";
        string link = "";
        string filepath = "C:\\records\\user.csv";
        public View_Records()
        {
            InitializeComponent();
            connectionString = strings.connectionStringClients;



        }

        private void dataAdapter()
        {

        }

        private void getPatients()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            
            if (radioInfo == "ID NUMBER")
            {
                
                string id = txtBox.Text;
                userID = id; ;
                string value = "";
                string selectQuery = "SELECT * FROM Clients WHERE PatientID = @PatientID";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
                selectCommand.Parameters.AddWithValue("@PatientID", id);

                // SqlDataReader reader = selectCommand.ExecuteReader();

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                sqlDataAdapter.Fill(dataTable);
                datagrid.ItemsSource = dataTable.DefaultView;

               


                MessageBox.Show("ID Search: " + id);
                MessageBox.Show(value);
            }

            if (radioInfo == "FIRSTNAME")
            {
                //SqlConnection connection = new SqlConnection(connectionString);
                string firstName = txtBox.Text;
                string selectQuery = "SELECT * FROM Clients WHERE FirstName = @FirstName";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);



                selectCommand.Parameters.AddWithValue("@Firstname", firstName);

                MessageBox.Show("Firstname Search: " + firstName);


                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                sqlDataAdapter.Fill(dataTable);
                datagrid.ItemsSource = dataTable.DefaultView;
            }

            if (radioInfo == "SURNAME")
            {
                //SqlConnection connection = new SqlConnection(connectionString);
                string surname = txtBox.Text;
                string selectQuery = "SELECT * FROM TeastDatabase WHERE surname = @surname";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);



                selectCommand.Parameters.AddWithValue("@surname", surname);

                MessageBox.Show("surname Search: " + surname);
            }
            if (txtBox.Text=="*")
            {
                //SqlConnection connection = new SqlConnection(connectionString);
                string selectQuery = "SELECT * FROM Patients";
                SqlCommand selectCommand = new SqlCommand(selectQuery, connection);

                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
                sqlDataAdapter.Fill(dataTable);
                datagrid.ItemsSource = dataTable.DefaultView;
              //  ExportDataTableToCsv(dataTable, filepath);
            }
        }


        private void ExportDataTableToCsv(DataTable dataTable, string filePath)
        {
            // Create a StreamWriter to write to the CSV file
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write the header row with column names
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    writer.Write(dataTable.Columns[i].ColumnName);
                    if (i < dataTable.Columns.Count - 1)
                    {
                        writer.Write(",");
                    }
                }
                writer.WriteLine();

                // Write the data rows
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        writer.Write(row[i].ToString());
                        if (i < dataTable.Columns.Count - 1)
                        {
                            writer.Write(",");
                        }
                    }
                    writer.WriteLine();
                }
            }
            MessageBox.Show("File exported");
        }

            private void Search_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            getPatients();
            getUserDocsAsync(userID);

          



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

        private async Task getUserDocsAsync (string id)
        {
            string userID = id;
             MessageBox.Show("open");
             var connectionString = "DefaultEndpointsProtocol=https;AccountName=teststorelk;AccountKey=XJk7EfgIJCCsWSMgJCZAzSKWvVYLp+Lq8gfimrdd0r8uNS5jeaGD0LEdn0vrW1DGF+52D5KuujiF+AStsnh1Dw==;EndpointSuffix=core.windows.net";
             //var blobServiceClient = new BlobServiceClient(connectionString);

             var containerName = "testarch";
             //var containerClient = blobServiceClient.GetBlobContainerClient(containerName);
             var blobName = "C:/KamvaCloud/usersFiles/"+id+".pdf"; // Replace with the name of the file you're searching for

            // var blobClient = containerClient.GetBlobClient(blobName);

            //if (await blobClient.ExistsAsync())
            //{
            //    // The blob exists, and you can provide it to the user for download


            //    // Here, you can provide the response to your user for download
            //    // For example, save it to a file or stream it to the user
            //}
            //else
            //{
            //    MessageBox.Show($"{blobName} does not exist.");
            //    // The blob does not exist, handle the case where the file isn't found
            //    // You can display a message to the user indicating that the file does not exist
            //}


            // Create a BlobServiceClient
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            // Get a reference to the container
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient(containerName);

            // Get a reference to the blob
            BlobClient blobClient = containerClient.GetBlobClient(blobName);

            // Get the URI or link to the blob
            Uri blobUri = blobClient.Uri;

            // Print or use the blob's URI
            MessageBox.Show("Blob URL: " + blobUri.ToString());

            link=blobUri.ToString();


        }

        private void btnViewFile_Click(object sender, RoutedEventArgs e)
        {
            PDFViewer p = new PDFViewer(link);
            p.Show();
        }
    }
}
    


       
    

