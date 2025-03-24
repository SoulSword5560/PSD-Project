using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace testProjek.View
{
    public partial class homeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["user"] == null)
            { 
                Response.Redirect("loginPage.aspx");
            }
            if (Request.Cookies["user"] != null && Request.Cookies["user"]["username"] != null)
            {
                homeTXT.Text = "WELLCOME " + Request.Cookies["user"]["username"];
            }
            else if (Session["user"] != null)
            {
                homeTXT.Text = "WELLCOME " + Session["user"].ToString();
            }
            else
            {
                homeTXT.Text = "WELLCOME " + "Guest";
            }
        }
    }
}