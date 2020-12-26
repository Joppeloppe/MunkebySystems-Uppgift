using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using WebApplication.Tables;

namespace WebApplication.Views
{
    public partial class User : System.Web.UI.Page
    {
        private bool isPasswordSame = false;

        private Site _masterPage;
        private Site MasterPage
        {
            get
            {
                if (_masterPage == null)
                {
                    _masterPage = Page.Master as Site;
                }
                return _masterPage;
            }

            set
            {
                _masterPage = value;
            }
        }

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void UpdatePassword(string hashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand(
                    string.Format("UPDATE users SET password = '{0}' WHERE username = '{1}'; ", 
                    hashedPassword, HttpContext.Current.User.Identity.Name),
                    connection);

                cmd.ExecuteNonQuery();
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // New passwords differ. Error message should be shown from TextChange event
            if (!isPasswordSame) return;

            string passwordHash = UsersTable.GetUserPassword(HttpContext.Current.User.Identity.Name);

            // Verify that the input password is the same as the stored password.
            if (BCrypt.Net.BCrypt.Verify(TextBoxPassword.Text, passwordHash)) {
                UpdatePassword(UsersTable.HashPassword(TextBoxNewPassword.Text));
                MasterPage.ShowSuccessful("Passwords updated!");
            }
            else
            {
                MasterPage.ShowError("Login failed! \n Old password is wrong.");
                return;
            }
        }

        protected void TextBoxPasswordCheck_TextChanged(object sender, EventArgs e)
        {
            // New password has been entered in differently.
            if (TextBoxNewPassword.Text != TextBoxPasswordCheck.Text)
            {
                MasterPage.ShowError("New Passwords do not match!");
                isPasswordSame = false;
                return;
            }
            else
            {
                isPasswordSame = true;
                MasterPage.ShowSuccessful("Passwords match!");
            }
        }
    }
}