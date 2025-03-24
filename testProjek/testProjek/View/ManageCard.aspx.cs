using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.handler;
using testProjek.Model;

namespace testProjek.View
{
    public partial class ManageCard : System.Web.UI.Page
    {
        cardHandler cardHandler = new cardHandler();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refreshGrid();
            } 
        }
        protected string ConvertIsFoil(object isFoil)
        {
            if (isFoil is byte[] byteArray)
            {
                return byteArray.Length > 0 && byteArray[0] == 1 ? "Yes" : "No";
            }
            return "Unknown";
        }

        public void refreshGrid()
        {
            List<Card> list = cardHandler.getCards();
            gv.DataSource = list;
            gv.DataBind();
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gv.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            cardHandler.deleteCard(id);
            refreshGrid();
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gv.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);
            Card card = cardHandler.getCardByID(id);
            idTB.Text = id.ToString();
            nameTB.Text = card.CardName;
            priceTB.Text = card.CardPrice.ToString();
            typeTB.Text = card.CardType;
            descTB.Text = card.CardDesc;
        }

        protected void updateBTN_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTB.Text);
            string name = nameTB.Text;
            decimal price = Convert.ToDecimal(priceTB.Text);
            string type = typeTB.Text;
            string desc = descTB.Text;
            int isFoil = int.Parse(foilDDL.SelectedValue);
            Card card = cardHandler.createCard(name,price, type, desc, isFoil);
            cardHandler.updateCard(id,card);
            refreshGrid();
        }
    }
}