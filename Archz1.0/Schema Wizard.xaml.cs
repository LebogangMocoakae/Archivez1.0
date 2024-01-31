using Archz1._0.Database_Functions.Helpers;
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
    /// Interaction logic for Schema_Wizard.xaml
    /// </summary>
    public partial class Schema_Wizard : Window
    {

        private string tableName;
        public Schema_Wizard()
        {
            InitializeComponent();
        }

        private void AddDynamicItem(string itemName, string itemType)
        {
            // Create a new control based on user input
            TextBlock dynamicItem = new TextBlock();
            dynamicItem.Text = $"{itemType} {itemName}";

            // Add the dynamic item to the panel
            stackPanel.Children.Add(dynamicItem);

            // Store the item information for future use (e.g., when saving to the database)
            // You might want to create a data structure to store this information, such as a List<ItemInfo>
            // For simplicity, I'll use a dictionary here
            itemInformation[itemName] = itemType;

            
        }

        private void AddDynamicItems(int numberOfItems)
        {
            // Add the specified number of dynamic items
            for (int i = 1; i <= numberOfItems; i++)
            {
                AddDynamicItem($"Item {i}", "string");
            }
        }
        private Dictionary<string, string> itemInformation = new Dictionary<string, string>();


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Ask the user for the new item's name (you might use a dialog box)
            string newItemName = Microsoft.VisualBasic.Interaction.InputBox("Enter the new item name (Please note item name is case sensitve!):", "Add New Item", "");
            string newItemType = Microsoft.VisualBasic.Interaction.InputBox("Enter the type of the new item (e.g., INT, DECIMAL, CHAR):", "Specify Item Type", "");

            //Add the dynamic item if the user entered a name
            if (!string.IsNullOrEmpty(newItemName))
            {
                AddDynamicItem(newItemName, newItemType);
            }
        }

        private void AddToDatabase_Click(object sender, RoutedEventArgs e)
        {


            // Prompt the user for the table name
            tableName = Microsoft.VisualBasic.Interaction.InputBox("Enter the table name:", "Specify Table Name", "");

            if (string.IsNullOrEmpty(tableName))
            {
                MessageBox.Show("Table name cannot be empty.");
                return;
            }

            string schemaName = "dbo"; // Set your schema name
            strings strings = new strings();

            try
            {
                // Create an instance of SchemaWizardDbHelper with your connection string
                SchemaWizardDbHelper dbHelper = new SchemaWizardDbHelper(strings.connectionString);

                // Call the method to create schema and table
                dbHelper.CreateSchemaAndTable(itemInformation, schemaName, tableName);

                MessageBox.Show($"Schema '{schemaName}' and table '{tableName}' created successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating schema and table: {ex.Message}");
            }
        }
    }
}

