using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for Add_Custom_Record.xaml
    /// </summary>
    public partial class Add_Custom_Record : Window
    {
        strings strings = new strings();
        string tableName = "test1";
        Dictionary<string, string> columnValues = new Dictionary<string, string>();
        

        public Add_Custom_Record()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // Replace with your table name
            string connectionString = strings.connectionString; // Replace with your database connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Retrieve columns for the specified table
                DataTable schemaTable = connection.GetSchema("Columns", new[] { null, null, tableName });

                // Create TextBoxes dynamically
                foreach (DataRow row in schemaTable.Rows)
                {
                    string columnName = row["COLUMN_NAME"].ToString();

                    // Create a Label and TextBox for each column
                    Label label = new Label { Content = columnName, Margin = new Thickness(5)};
                    TextBox textBox = new TextBox { Name = $"txt{columnName}", Margin = new Thickness(5)};

                    // Add the Label and TextBox to a StackPanel (or any other container)
                    stackPanel.Children.Add(label);
                    stackPanel.Children.Add(textBox);

                    // Add an event handler to update the dictionary when the TextBox text changes
                    textBox.TextChanged += (s, args) =>
                    {
                        columnValues[columnName] = textBox.Text;
                    };
                    btnSaveData.IsEnabled = true;
                }
            }
        }

        private void InsertDataIntoDatabase(string tableName, Dictionary<string, string> columnValues)
        {
            string connectionString = strings.connectionString; // Replace with your database connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();


                // Create SQL command to insert data into the specified table
                string columns = string.Join(", ", columnValues.Keys);
                string values = string.Join(", ", columnValues.Values.Select(value => $"'{value}'"));
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the SQL command
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveDataClick(object sender, RoutedEventArgs e)
        {
// Use the columnValues dictionary to insert data into the database
            InsertDataIntoDatabase(tableName, columnValues);
        }
    }

}





