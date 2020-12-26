using System;
using WebApplication.Tables;
using WebApplication.Views;

namespace WebApplication
{
    public partial class AddNewUser : System.Web.UI.Page
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
            try
            {
                if (!FieldsAreValid()) return;

                UsersTable.AddUser(TextBoxUsername.Text, UsersTable.HashPassword(TextBoxPassword.Text));
                MasterPage.ShowSuccessful(string.Format("Successfully added user '{0}'!", TextBoxUsername.Text));

            }
            catch (Exception ex)
            {
                MasterPage.ShowError(string.Format("Error while adding user! '{0}'", ex.Message));
            }
        }

        // TODO
        // Error messages can be improved, e.g: 
        // add error label after each textbox and have if/else for each textbox seperatly
        private bool FieldsAreValid()
        {
            if(string.IsNullOrWhiteSpace(TextBoxUsername.Text))
            {
                MasterPage.ShowError("Username field is empty!");
                return false;
            }
            else if(TextBoxUsername.Text.Length < 4)
            {
                MasterPage.ShowError("Username must be atleast 4 characters long!");
                return false;
            }
            else if (TextBoxPassword.Text.Length < 8 || string.IsNullOrWhiteSpace(TextBoxPassword.Text))
            {
                MasterPage.ShowError("Password must be atleast 8 characters long!");
                return false;
            }

            return true;
        }
    }
}