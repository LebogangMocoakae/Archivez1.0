using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
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
        strings strings = new strings();
        string conn;


        public string connectionString;

        string storageAccountName = "teststorelk";
        string storageAccountKey = "XJk7EfgIJCCsWSMgJCZAzSKWvVYLp+Lq8gfimrdd0r8uNS5jeaGD0LEdn0vrW1DGF+52D5KuujiF+AStsnh1Dw==";
        string containerName = "testarch";
        string selectedFilePath = string.Empty;
        string filename = string.Empty;

        public Add_Record(string user, string database)
        {
            InitializeComponent();
            LoginUser.Text = "Logged in user: "+ user;
            selected_database.Text = "Selected Database: " + database;


        }

        private void addUser()
        {
            connectionString = strings.connectionStringClients;
            string Id = txtID.Text.Trim();
            string firstName = txtName.Text.Trim();
            string surname = txtSurname.Text.Trim();
            string gender = txtGender.Text.Trim();
            string race = txtRace.Text.Trim();
            string visitReason = txtVisitReason.Text.Trim();
            if (txtID.Text == string.Empty || txtName.Text == string.Empty || txtSurname.Text == string.Empty || txtRace.Text == string.Empty)
            {
                MessageBox.Show("please enter all fields!!!");
            }
            else
            {
                SqlConnection connection = new SqlConnection(connectionString);
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Clients (PatientID, FirstName, surname,Gender,Race,VisitReason) VALUES (@PatientID, @FirstName, @surname, @Gender, @Race, @VisitReason)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Connection = connection;
                        command.Parameters.AddWithValue("@PatientID", Id);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@surname", surname);
                        command.Parameters.AddWithValue("@Gender", gender);
                        command.Parameters.AddWithValue("@Race", race);
                        command.Parameters.AddWithValue("@VisitReason", visitReason);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Complete");
                        //UploadFileToBlobStorageAsync(selectedFilePath, filename);
                    }
                    connection.Close();


                }
            }
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //if (SelectedFileLabel.Text == "")
            //{
            //    MessageBox.Show("Please upload file!");
            //}
            //else
            //{
                addUser();
                //UploadFileToBlobStorageAsync(selectedFilePath, filename);
            //}
        }




        private async Task UploadFileToBlobStorageAsync(string filePath, string blobName)
        {
            string storageConnectionString = $"DefaultEndpointsProtocol=https;AccountName={storageAccountName};AccountKey={storageAccountKey};EndpointSuffix=core.windows.net";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);

            try
            {
                await container.CreateIfNotExistsAsync();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);

                using (var fileStream = File.OpenRead(filePath))
                {
                    await blockBlob.UploadFromStreamAsync(fileStream);
                }

                MessageBox.Show("File uploaded to Azure Blob Storage.");
            }
            catch (StorageException ex)
            {
                MessageBox.Show($"Error uploading file to Azure Blob Storage: {ex.Message}");
            }
        }



        private void btnUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                SelectedFileLabel.Text = selectedFilePath;
                filename= openFileDialog.FileName;
            }
        }
    }
}
