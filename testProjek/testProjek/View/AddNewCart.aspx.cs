using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.Model;

namespace testProjek.View
{
    public partial class AddNewCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cartController cartController = new cartController();
            if (!IsPostBack)
            {
                
            }
        }

        protected void lb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void qtyTxt_TextChanged(object sender, EventArgs e)
        {

        }

        protected void coutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~View/BuyCard.aspx");
        }
    }
}