using System;
using WebApplication.Tables;

namespace WebApplication.Views
{
    public partial class Login : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            // Get hashed password from database
            string passwordHash = UsersTable.GetUserPassword(TextBoxUsername.Text);

            // Check to see if the username exists in the database and has returned a password.
            if (string.IsNullOrWhiteSpace(passwordHash))
            {
                // For security reasons we show username OR password is wrong.
                MasterPage.ShowError("Login failed! \n Username or password is wrong.");
                return;
            }
            
            // Verify that the input password is the same as the stored password.
            if (BCrypt.Net.BCrypt.Verify(TextBoxPassword.Text, passwordHash))
            {
                MasterPage.ShowSuccessful("Logged in user successfully!");
                // Change to true if 'keep me logged in' functionality exists.
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(TextBoxUsername.Text, false);
            }
            else
            {
                // For security reasons we show username OR password is wrong.
                MasterPage.ShowError("Login failed! \n Username or password is wrong.");
            }
        }

    }
}