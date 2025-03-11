using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.View
{
    public partial class loginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user"] != null)
            {
                if (Session["role"]?.ToString() == "Customer" || Request.Cookies["user"]["role"] == "Customer")
                {
                    Response.Redirect("homeCustomer.aspx");
                }
                else
                {
                    Response.Redirect("homeAdmin.aspx");
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = nameTB.Text;
            string password = passTB.Text;

            if (username == " " && password == " ")
            {
                errorMsg.Text = "please fill the data";
                return;
            }
            User user = UserRepository.getUser(username, password);
            if (user == null)
            {
                errorMsg.Text = "invalid account";
                return;
            }
            else
            {
                Session["user"] = user.UserName;
                Session["role"] = user.UserRole;
                if (remember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user");
                    cookie["username"] = user.UserName;
                    cookie["role"] = user.UserRole;
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                }
                if (user.UserRole == "Customer")
                {
                    Response.Redirect("~/View/homeCustomer.aspx");
                }
                else
                {
                    Response.Redirect("~/View/homeAdmin.aspx");
                }
            }
        }
    }
}