
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace EmployeeManagers
{

    public class EmployeManager
    {
        string ConnectionString = "Data Source=DESKTOP-4PLP0SR\\SQLEXPRESS;Initial Catalog=Practice;Trusted_Connection = true";
        public void AddEmployee(string Name,string Position,decimal Salary)
        {
           
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "INSERT INTO Employees (Name,Position,Salary) VALUES(@Name,@Position,@Salary)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@name", Name);
                command.Parameters.AddWithValue(@"Position", Position);
                command.Parameters.AddWithValue(@"Salary", Salary);

                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "User added successfully" :"Error adding user") ;
            }

        }

        public void GetEmployees()
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["ID"]}, Name: {reader["Name"]}, Position: {reader["Position"]}, Salary: {reader["Salary"]}");
                }
            }
        }


        public void UpdateEmployee(int id, string name, string position, decimal salary)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "UPDATE Employees SET Name=@name, Position=@position, Salary=@salary WHERE ID=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@position", position);
                command.Parameters.AddWithValue("@salary", salary);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "Employee updated successfully." : "Error updating employee.");
            }
        }


        public void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string query = "DELETE FROM Employees WHERE ID=@id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(rowsAffected > 0 ? "Employee deleted successfully." : "Error deleting employee.");
            }
        }


    }
}
