using System;
using System.Web;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication.Views
{
    public partial class Site : System.Web.UI.MasterPage
    {
        public string loggedInUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            ResetPage();

            if (!string.IsNullOrWhiteSpace(HttpContext.Current.User.Identity.Name))
            {
                HtmlGenericControl li = new HtmlGenericControl("li");
                HtmlAnchor a = new HtmlAnchor();
                a.HRef = "User.aspx";
                a.InnerHtml = HttpContext.Current.User.Identity.Name;
                a.Attributes.Add("class", "navbar-brand navbar-inverse");
                li.Controls.Add(a);
                ulUserInfo.Controls.Add(li);

                li = new HtmlGenericControl("li");
                HtmlButton btn = new HtmlButton();
                btn.Attributes.Add("class", "btn btn-primary");
                btn.InnerHtml = "Logout";
                btn.ServerClick += Logout;
                li.Controls.Add(btn);
                ulUserInfo.Controls.Add(li);
            
                ulLoginInfo.Visible = false;
                ulUserInfo.Visible = true;
            }
            else
            {
                ulLoginInfo.Visible = true;
                ulUserInfo.Visible = false;
            }
        }

        private void Logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();

            // Clear cookies
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);

            Response.Redirect("Login.aspx");
        }

        public void ResetPage()
        {
            LabelSuccess.Text =
                LabelError.Text = string.Empty;

            divSuccess.Visible =
                divError.Visible = false;
        }

        public void ShowSuccessful(string message)
        {
            LabelSuccess.Text = message;
            divSuccess.Visible = true;
        }

        public void ShowError(string errorMessage)
        {
            LabelError.Text = errorMessage;
            divError.Visible = true;
        }
    }
}