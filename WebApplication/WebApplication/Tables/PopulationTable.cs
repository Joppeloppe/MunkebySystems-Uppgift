using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication.Tables
{
    public static class PopulationTable
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;

        public static DataTable GetPointChartData(string country)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM countryPopulation WHERE [Country Name] = @countryName",
                    connection);
                cmd.Parameters.AddWithValue("@countryName", country);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);
                reader.Close();

                return table;

            }
        }

        public static DataTable GetPieChartData(int year, string[] countries)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                DataTable table = new DataTable();
                foreach (string country in countries)
                {
                    if (country == null) continue;

                    SqlCommand cmd = new SqlCommand(string.Format("SELECT [Country Name], [{0}] FROM countryPopulation WHERE [Country Name] = @countryName", year),
                        connection);
                    cmd.Parameters.AddWithValue("@countryName", country);

                    SqlDataReader reader = cmd.ExecuteReader();

                    table.Load(reader);
                    reader.Close();
                }

                return table;

            }
        }

    }
}