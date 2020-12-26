using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using WebApplication.Tables;

namespace WebApplication.Views
{
    public partial class PopulationStatistics : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;
        private string[] pieChartCountries = new string[4];
        private DropDownList[] pieChartList;

        protected void Page_Load(object sender, EventArgs e)
        {
            SetDropDownListCountry(DropDownListCountry);
            SetDropDownListYear();

            pieChartList = new DropDownList[4] { DropDownList0, DropDownList1, DropDownList2, DropDownList3 };

            for (int i = 0; i < pieChartList.Length; i++)
            {
                SetDropDownListCountry(pieChartList[i]);
                // Is not default value
                if (pieChartList[i].SelectedIndex != 0)
                {
                    // If not default value, add value to pie chart countries array.
                    pieChartCountries[i] = pieChartList[i].SelectedValue;
                }
            }

            

            if (DropDownListYear.SelectedIndex != 0)
                SetPieChartData(PopulationTable.GetPieChartData(int.Parse(DropDownListYear.SelectedValue), pieChartCountries));
            if (DropDownListCountry.SelectedIndex != 0)
            {
                SetPointChartData(PopulationTable.GetPointChartData(DropDownListCountry.SelectedValue));
                Chart1.Titles[0].Text = "Population of " + DropDownListCountry.SelectedValue;
            }
        }

        private void SetDropDownListCountry(DropDownList dropDown)
        {
            //Drop down already populated.
            if (dropDown.Items.Count != 0) return;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("SELECT [Country Name] FROM countryPopulation", connection);

                SqlDataReader reader = cmd.ExecuteReader();

                ListItem li = new ListItem("-- Select a country --");
                dropDown.Items.Add(li);

                while (reader.Read())
                {
                    li = new ListItem(reader.GetString(0));
                    dropDown.Items.Add(li);
                }

                reader.Close();
            }
        }
        private void SetDropDownListYear()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    string.Format("SELECT * FROM countryPopulation WHERE [Country Name] = 'Sweden'"),
                    connection);

                SqlDataReader reader = cmd.ExecuteReader();

                DataTable table = new DataTable();
                table.Load(reader);
                reader.Close();

                DropDownListYear.Items.Add("-- Please select a year --");
                // i=4 to start at first year column.
                for (int i = 4; i < table.Columns.Count; i++)
                {
                    DropDownListYear.Items.Add(table.Columns[i].ToString());
                }
            }
        }

        protected void DropDownListCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Default text is selected. Do nothing.
            if (DropDownListCountry.SelectedIndex == 0) return;

            PopulationTable.GetPointChartData(DropDownListCountry.SelectedValue);
            Chart1.Titles[0].Text = "Population of " + DropDownListCountry.SelectedValue;
        }

        protected void DropDownListPieChart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListYear.SelectedIndex != 0)
                PopulationTable.GetPieChartData(int.Parse(DropDownListYear.SelectedValue), pieChartCountries);
        }

        private void SetPieChartData(DataTable table)
        {
            Chart2.Series["Series1"].Points.Clear();
            Chart2.Legends[0].Enabled = true;

            for (int i = 0; i < table.Rows.Count; i++)
            {
                // Country - Population
                Chart2.Series["Series1"].Points.AddXY(
                    table.Rows[i].ItemArray[0].ToString(), table.Rows[i].ItemArray[1]);
            }
        }

        private void SetPointChartData(DataTable table)
        {
            Chart1.Series["Series1"].Points.Clear();
            // Create datapoints, i=4 to start at first year column.
            for (int i = 4; i < table.Columns.Count; i++)
            {
                // Year - Population
                Chart1.Series["Series1"].Points.AddXY(table.Columns[i].ToString(), table.Rows[0][i]);
            }
        }
    }
}