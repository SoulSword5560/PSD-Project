using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.handler;
using testProjek.Model;

namespace testProjek.View
{
    public partial class insert : System.Web.UI.Page
    {
        cardController cardController = new cardController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            decimal price = Convert.ToDecimal(priceTB.Text);
            string type = typeTB.Text;
            string desc = descTB.Text;
            int isFoil = int.Parse(foilDDL.SelectedValue);
            errorMsg.Text = cardController.cardValidation(name,price,type,desc,isFoil);
            Response.Redirect("~/View/ManageCard.aspx");
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ManageCard.aspx");
        }
    }
}