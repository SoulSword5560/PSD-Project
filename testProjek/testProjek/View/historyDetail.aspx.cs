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
    public partial class historyDetail : System.Web.UI.Page
    {
        transactionReportController controller = new transactionReportController();
        protected void Page_Load(object sender, EventArgs e)
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
            var list = controller.getHistoryByUser(userId);
            if (list != null && list.Count > 0)
            {
                dynamic item = list[0];
                cIdLbl.Text = "Card ID: " + item.CardID;
                cNameLbl.Text = "Card Name: " + item.CardName;
                tIdLbl.Text = "Transaction ID: " + item.TransactionID;
                tDateLbl.Text = "Transaction Date: " + item.TransactionDate.ToString("dd MMM yyyy");
                tStsLbl.Text = "Status: " + item.Status;
                tQtyLbl.Text = "Quantity: " + item.Quantity;
                cPriceLbl.Text = "Unit Price: " + item.CardPrice;
                totalLbl.Text = "Total: " + item.Subtotal;
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/history.aspx");
        }
    }
}