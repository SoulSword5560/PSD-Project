using System;
using System.Web;
using System.Web.UI;
using testProjek.Controller;

namespace testProjek.View
{
    public partial class navbarAdmin : System.Web.UI.MasterPage
    {
        userController Controller = new userController();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            Controller.RedirectIfNotAuthenticated(Session, Request, Response);
            if (Request.Cookies["user"] != null && Request.Cookies["user"]["username"] != null)
            {
                welcome.Text ="Hello " + Request.Cookies["user"]["username"];
            }
            else if (Session["user"] != null)
            {
                welcome.Text = "Hello " +Session["user"].ToString();
            }
            else
            {
                welcome.Text = "Hello " + "Guest";
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Session["user"] = null;
            if (Request.Cookies["user"] != null)
            {
                HttpCookie Cookie = new HttpCookie("user");
                Cookie.Expires = DateTime.Now.AddDays(-1); 
                Response.Cookies.Add(Cookie);
            }

            Response.Redirect("~/View/loginPage.aspx");
        }

        protected void searchBar_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            string query = searchBar.Text;

            if (!string.IsNullOrEmpty(query))
            {
                Response.Redirect($"~/View/manageCard.aspx?query={Server.UrlEncode(query)}");
            }
            else
            {
                Response.Redirect("~/View/manageCard.aspx");
            }
        }
    }
}
