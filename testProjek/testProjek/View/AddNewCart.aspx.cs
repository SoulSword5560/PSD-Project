using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.View
{
    public partial class AddNewCart : System.Web.UI.Page
    {
        cartController cartController = new cartController();
        cardController cardController = new cardController();
        databaseEntities1 db = new databaseEntities1();
        transactionHeaderController thc = new transactionHeaderController();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string userIdd;
                if (Session["id"] != null)
                {
                    userIdd = Session["id"].ToString();
                }
                else
                {
                    userIdd = Request.Cookies["user"]["id"].ToString();
                }
                int userId = Convert.ToInt32(userIdd);
                if (userId == null)
                {
                    Response.Redirect("~/View/loginPage.aspx");
                    return;
                }

                userIdHidden.Value = userId.ToString();
                string query = Request.QueryString["query"];
                if (!string.IsNullOrEmpty(query))
                {
                    int cartId;
                    if (int.TryParse(query, out cartId))
                    {
                        Cart cart = cartController.getCartByID(cartId);
                        List<Cart> list = new List<Cart>();
                        if (cart != null)
                        {
                            list.Add(cart);
                        }
                        gridview.DataSource = list;
                        gridview.DataBind();
                    }
                    else
                    {
                        refreshGrid();
                    }
                }
                else
                {
                    refreshGrid();
                }
            }
        }
        public void refreshGrid()
        {
            var carts = db.Carts.Include("Card").ToList();

            var result = carts.Select(c => new
            {
                CartId = c.CartID,
                CardName = c.Card.CardName,
                CardPrice = c.Card.CardPrice,
                Quantity = c.Quantity,
                Subtotal = c.Quantity * c.Card.CardPrice
            }).ToList();
            decimal total;
            total = result.Sum(r => r.Subtotal);
            TotalTxt.Text = "Total: $" + total;
            gridview.DataSource = result;
            gridview.DataBind();
        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblNumber = (Label)e.Row.FindControl("lblNumber");
                if (lblNumber != null)
                {
                    lblNumber.Text = (e.Row.RowIndex + 1).ToString();
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(idTxt.Text);
            int quantity = Convert.ToInt32(updTxt.Text);
            cartController.updateQuantity(id, quantity);
            refreshGrid();
            idTxt.Text = "";
            updTxt.Text = "";
        }

        protected void coutBtn_Click(object sender, EventArgs e)
        {
            
            string id = userIdHidden.Value;
            
            if (!string.IsNullOrEmpty(id))
            {
                int userid = Convert.ToInt32(id);
                var carts = db.TransactionDetails.Include("Card").Where(c => c.TransactionHeader.CustomerID == userid).ToList();
                var detail = carts
                 .GroupBy(c => c.CardID)
                 .Select(g => new TransactionDetail
                 {
                     CardID = g.Key,
                     Quantity = g.Sum(x => x.Quantity)
                 }).ToList();

                thc.addNewTransaction(Convert.ToInt32(id), DateTime.Now, detail);
                cartController.deleteAllCart(Convert.ToInt32(id));
                ClientScript.RegisterStartupScript(this.GetType(), "popup", $"alert('Congrats, you have done do check out.');", true);
            }
            refreshGrid();
        }

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gridview.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            cartController.deleteCart(id);
            refreshGrid();
        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridview.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            int quantity = Convert.ToInt32(row.Cells[4].Text);
            idTxt.Text = id.ToString();
            updTxt.Text = quantity.ToString();
        }

        protected void gridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gridview.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[1].Text);
            cartController.deleteCart(id);
            refreshGrid();
        }

        protected void clearBtn_Click(object sender, EventArgs e)
        {
            string userid = userIdHidden.Value;
            if (!string.IsNullOrEmpty(userid))
            {
                cartController.deleteAllCart(Convert.ToInt32(userid));
            }
            refreshGrid();
        }
    }
}