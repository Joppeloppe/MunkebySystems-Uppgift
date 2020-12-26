using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication.Tables
{
    public static class UsersTable
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

        public static void AddUser(string username, string hashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO users(username, password) VALUES(@username, @password)", connection);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                cmd.ExecuteNonQuery();
            }
        }

        public static string GetUserPassword(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT password FROM users WHERE username = @username", connection);
                cmd.Parameters.AddWithValue("@username", username);

                return (string)cmd.ExecuteScalar();
            }
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 8);
        }
    }
}