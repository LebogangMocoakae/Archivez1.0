using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archz1._0.Database_Functions.Helpers
{
    public class SchemaWizardDbHelper
    {
        private string connectionString; // Set your database connection string here

        public SchemaWizardDbHelper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateSchemaAndTable(Dictionary<string, string> itemInformation, string schemaName, string tableName)
        {
            if (itemInformation == null || itemInformation.Count == 0)
            {
                throw new ArgumentException("itemInformation cannot be null or empty.");
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create schema if not exists
                CreateSchema(connection, schemaName);

                // Create table
                CreateTable(connection, schemaName, tableName, itemInformation);
            }
        }

        private void CreateSchema(SqlConnection connection, string schemaName)
        {
            using (SqlCommand command = new SqlCommand($"IF NOT EXISTS (SELECT 1 FROM sys.schemas WHERE name = '{schemaName}') EXEC('CREATE SCHEMA {schemaName}')", connection))
            {
                command.ExecuteNonQuery();
            }
        }

        private void CreateTable(SqlConnection connection, string schemaName, string tableName, Dictionary<string, string> itemInformation)
        {
            using (SqlCommand command = new SqlCommand($"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = '{schemaName}' AND TABLE_NAME = '{tableName}') " +
                                                        $"CREATE TABLE [{schemaName}].[{tableName}] (", connection))
            {
                // Add columns based on itemInformation
                foreach (var item in itemInformation)
                {
                    command.CommandText += $"{item.Key} {GetSqlTypeFromItemType(item.Value)}, ";
                }

                // Remove the trailing comma and close the parentheses
                command.CommandText = command.CommandText.TrimEnd(',', ' ') + ")";

                command.ExecuteNonQuery();
            }
        }

        private string GetSqlTypeFromItemType(string itemType)
        {
            // Map your application-specific item types to SQL Server data types
            switch (itemType.ToUpper())
            {
                case "INT":
                    return "INT";
                case "DECIMAL":
                    return "DECIMAL(18,4)"; // Adjust precision and scale as needed
                case "CHAR":
                    return "CHAR(125)"; // Adjust size as needed
                case "NVARCHAR":
                    return "CHAR(512)"; // Adjust size as needed
                case "TEXT":
                    return "TEXT(1024)"; // Adjust size as needed
               
                default:
                    throw new ArgumentException($"Unsupported item type (Please conatact Tech support to add dataype): {itemType}");
            }
        }
    }
}
