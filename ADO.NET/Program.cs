using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace AdoNetExercises
{
    class Program
    {
        // Connection string pointing to local SQLExpress or LocalDB. Adjust as needed.
        private const string ConnectionString = "Server=localhost;Database=CompanyDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Console.WriteLine("==========================================================");
            Console.WriteLine("      Exercise 30: Perform CRUD Operations using ADO.NET   ");
            Console.WriteLine("==========================================================\n");

            Console.WriteLine("This program attempts to connect to a SQL Server database 'CompanyDB'");
            Console.WriteLine($"using connection string:\n  \"{ConnectionString}\"\n");

            try
            {
                // Test the database connection
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    Console.WriteLine("Attempting to connect to SQL Server...");
                    connection.Open();
                    Console.WriteLine("✔ Connection Successful!");
                    
                    // Run the CRUD operations
                    RunDatabaseCrud(connection);
                }
            }
            catch (SqlException sqlEx)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n⚠ COULD NOT CONNECT TO DATABASE.");
                Console.WriteLine($"Error Details: {sqlEx.Message}");
                Console.ResetColor();

                Console.WriteLine("\n----------------------------------------------------------");
                Console.WriteLine("              DATABASE SETUP INSTRUCTIONS                ");
                Console.WriteLine("----------------------------------------------------------");
                Console.WriteLine("To run this database exercise successfully, please:");
                Console.WriteLine("1. Ensure SQL Server is running locally.");
                Console.WriteLine("2. Create a database named 'CompanyDB'.");
                Console.WriteLine("3. Run the following SQL script to create the 'Employees' table:");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(GetSqlScript());
                Console.ResetColor();
                Console.WriteLine("4. Update the connection string at the top of 'Program.cs' if necessary.");
                Console.WriteLine("----------------------------------------------------------\n");

                Console.WriteLine("=== Simulated ADO.NET Code Execution Walkthrough ===");
                Console.WriteLine("If the database were online, here is what this ADO.NET code would do:");
                RunSimulationWalkthrough();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey(true);
        }

        private static void RunDatabaseCrud(SqlConnection connection)
        {
            // Make sure the Employees table exists
            EnsureTableExists(connection);

            Console.WriteLine("\n--- Starting ADO.NET CRUD Operations ---\n");

            // 1. CREATE (Insert)
            Console.WriteLine("[CREATE] Inserting new employee 'Bob Jenkins'...");
            string insertSql = "INSERT INTO Employees (Name, Position, Salary) VALUES (@Name, @Position, @Salary); SELECT SCOPE_IDENTITY();";
            int newEmployeeId = 0;
            using (SqlCommand insertCmd = new SqlCommand(insertSql, connection))
            {
                insertCmd.Parameters.AddWithValue("@Name", "Bob Jenkins");
                insertCmd.Parameters.AddWithValue("@Position", "Data Analyst");
                insertCmd.Parameters.AddWithValue("@Salary", 65000.00m);
                
                object result = insertCmd.ExecuteScalar();
                newEmployeeId = Convert.ToInt32(result);
                Console.WriteLine($"✔ Inserted successfully. New EmployeeID: {newEmployeeId}");
            }

            // 2. READ (Select using SqlDataReader)
            Console.WriteLine("\n[READ] Reading all employees using SqlDataReader:");
            string selectSql = "SELECT EmployeeID, Name, Position, Salary FROM Employees;";
            using (SqlCommand selectCmd = new SqlCommand(selectSql, connection))
            {
                using (SqlDataReader reader = selectCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        string position = reader.GetString(2);
                        decimal salary = reader.GetDecimal(3);
                        Console.WriteLine($"  ID: {id} | Name: {name} | Position: {position} | Salary: ${salary:N2}");
                    }
                }
            }

            // 3. UPDATE
            Console.WriteLine($"\n[UPDATE] Increasing salary for Employee ID {newEmployeeId}...");
            string updateSql = "UPDATE Employees SET Salary = @Salary WHERE EmployeeID = @EmployeeID;";
            using (SqlCommand updateCmd = new SqlCommand(updateSql, connection))
            {
                updateCmd.Parameters.AddWithValue("@Salary", 72000.00m);
                updateCmd.Parameters.AddWithValue("@EmployeeID", newEmployeeId);

                int rowsAffected = updateCmd.ExecuteNonQuery();
                Console.WriteLine($"✔ Update complete. Rows affected: {rowsAffected}");
            }

            // 4. READ using DataAdapter and DataSet/DataTable
            Console.WriteLine("\n[READ/ADAPTER] Fetching employees using SqlDataAdapter:");
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Employees", connection))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                
                Console.WriteLine($"  Filled DataTable with {table.Rows.Count} rows:");
                foreach (DataRow row in table.Rows)
                {
                    Console.WriteLine($"    Row -> ID: {row["EmployeeID"]}, Name: {row["Name"]}, Position: {row["Position"]}, Salary: ${Convert.ToDecimal(row["Salary"]):N2}");
                }
            }

            // 5. DELETE
            Console.WriteLine($"\n[DELETE] Deleting Employee ID {newEmployeeId} to clean up...");
            string deleteSql = "DELETE FROM Employees WHERE EmployeeID = @EmployeeID;";
            using (SqlCommand deleteCmd = new SqlCommand(deleteSql, connection))
            {
                deleteCmd.Parameters.AddWithValue("@EmployeeID", newEmployeeId);
                int rowsDeleted = deleteCmd.ExecuteNonQuery();
                Console.WriteLine($"✔ Delete complete. Rows affected: {rowsDeleted}");
            }

            Console.WriteLine("\n--- ADO.NET CRUD Operations Complete ---");
        }

        private static void EnsureTableExists(SqlConnection connection)
        {
            string checkTableSql = @"
                IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Employees' AND xtype='U')
                BEGIN
                    CREATE TABLE Employees (
                        EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
                        Name NVARCHAR(100) NOT NULL,
                        Position NVARCHAR(100) NOT NULL,
                        Salary DECIMAL(18,2) NOT NULL
                    );
                    
                    INSERT INTO Employees (Name, Position, Salary) VALUES 
                    ('Alice Smith', 'Software Engineer', 85000.00),
                    ('Charlie Brown', 'Project Manager', 90000.00);
                END";

            using (SqlCommand cmd = new SqlCommand(checkTableSql, connection))
            {
                cmd.ExecuteNonQuery();
            }
        }

        private static string GetSqlScript()
        {
            return @"CREATE DATABASE CompanyDB;
GO

USE CompanyDB;
GO

CREATE TABLE Employees (
    EmployeeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Position NVARCHAR(100) NOT NULL,
    Salary DECIMAL(18,2) NOT NULL
);
GO

-- Insert some starter records
INSERT INTO Employees (Name, Position, Salary) VALUES 
('Alice Smith', 'Software Engineer', 85000.00),
('Charlie Brown', 'Project Manager', 90000.00);
GO";
        }

        private static void RunSimulationWalkthrough()
        {
            Console.WriteLine("1. Instantiates SqlConnection with the server connection string.");
            Console.WriteLine("2. Opens the connection using connection.Open().");
            Console.WriteLine("3. Checks if the 'Employees' table exists; if not, creates it and seeds default data.");
            Console.WriteLine("4. Executes an INSERT command using SqlCommand with parameters (@Name, @Position, @Salary) to prevent SQL Injection.");
            Console.WriteLine("5. Retrieves the generated ID using ExecuteScalar() with SCOPE_IDENTITY().");
            Console.WriteLine("6. Reads data using SqlCommand and SqlDataReader (calling reader.Read() in a loop to fetch records).");
            Console.WriteLine("7. Performs an UPDATE query to modify the newly added employee's salary.");
            Console.WriteLine("8. Employs SqlDataAdapter.Fill(dataTable) to populate a disconnected DataTable and iterate over its DataRow collection.");
            Console.WriteLine("9. Runs a DELETE command to remove the temporary record and clean up the database.");
            Console.WriteLine("10. Properly disposes of all resources using C#'s 'using' statements to guarantee connections are closed.");
        }
    }
}
