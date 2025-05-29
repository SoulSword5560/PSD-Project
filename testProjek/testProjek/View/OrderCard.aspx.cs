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
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                string query = Request.QueryString["query"];
                if (!string.IsNullOrEmpty(query))
                {
                    List<Card> list = cardController.getCardByName(query);
                    ListBox1.DataSource = list;
                    ListBox1.DataBind();
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
            ListBox1.DataSource = list;
            ListBox1.DataBind();
        }

        protected string ConvertIsFoil(object isFoil)
        {
            if (isFoil is byte[] byteArray)
            {
                return byteArray.Length > 0 && byteArray[0] == 1 ? "Yes" : "No";
            }
            return "Unknown";
        }
        protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}