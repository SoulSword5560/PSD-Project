using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.handler;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.View
{
    public partial class loginPage : System.Web.UI.Page
    {
        userController userController = new userController();
        protected void Page_Load(object sender, EventArgs e)
        {
            userController.RedirectToUserHome(Session, Request, Response);
        }

        protected void login_Click(object sender, EventArgs e)
        {
            string username = nameTB.Text;
            string password = passTB.Text;

           
            User user = userController.validateLogin(username,password);
            if (user == null)
            {
                errorMsg.Text = "invalid account";
                return;
            }
            else
            {
                Session["id"] = user.UserID;
                Session["user"] = user.UserName;
                Session["role"] = user.UserRole;
                if (remember.Checked)
                {
                    HttpCookie cookie = new HttpCookie("user");
                    cookie["username"] = user.UserName;
                    cookie["role"] = user.UserRole;
                    cookie["id"] = user.UserID.ToString();
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