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
	public partial class OrderCard : System.Web.UI.Page
	{
        cardController cardController = new cardController();
        cartController cartController = new cartController();
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                string query = Request.QueryString["query"];
                if (!string.IsNullOrEmpty(query))
                {
                    List<Card> list = cardController.getCardByName(query);
                    gv.DataSource = list;
                    gv.DataBind();
                }
                else
                {
                    refreshGrid();
                }
            }
        }

        public void refreshGrid()
        {
            List<Card> list = cardController.getCards();
            gv.DataSource = list;
            gv.DataBind();
        }

        protected string ConvertIsFoil(object isFoil)
        {
            if (isFoil is byte[] byteArray)
            {
                return byteArray.Length > 0 && byteArray[0] == 1 ? "Yes" : "No";
            }
            return "Unknown";
        }

        protected void gv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gv_command(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandArgument != null)
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv.Rows[index];
                if (e.CommandName == "Buy")
                {
                    int id = Convert.ToInt32(row.Cells[0].Text);
                    string username = Session["user"].ToString();
                    cartController.addNewCart(id, username);
                    Response.Redirect("AddNewCart.aspx");
                }
                else if(e.CommandName == "AddToCart")
                {
                    int id = Convert.ToInt32(row.Cells[0].Text);
                    string username;
                    if (Session["user"] != null)
                    {
                        username = Session["user"].ToString();
                    }
                    else
                    {
                        username = Request.Cookies["user"]["username"].ToString();
                    }
                    cartController.addNewCart(id, username);
                    ClientScript.RegisterStartupScript(this.GetType(), "popup", $"alert('Added to cart.');", true);
                }
            }
        }
    }
}