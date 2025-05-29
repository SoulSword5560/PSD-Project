using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;

namespace testProjek.View
{
    public partial class homeAdmin : System.Web.UI.Page
    {
        userController Controller = new userController();
        protected void Page_Load(object sender, EventArgs e)
        {
            Controller.RedirectIfNotAuthenticated(Session, Request, Response);
            if (Request.Cookies["user"] != null && Request.Cookies["user"]["username"] != null)
            {
                homeTXT.Text = "WELCOME " + Request.Cookies["user"]["username"];
            }
            else if (Session["user"] != null)
            {
                homeTXT.Text = "WELCOME " + Session["user"].ToString();
            }
            else
            {
                homeTXT.Text = "WELCOME " + "Guest";
            }
        }
    }
}