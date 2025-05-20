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
    public partial class handleTransaction : System.Web.UI.Page
    {
        transactionHeaderController transactionHeaderController = new transactionHeaderController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                refreshGrid();
            }
        }
        protected void refreshGrid()
        {
            List<TransactionHeader> list = transactionHeaderController.getTransactionHeader();
            gv.DataSource = list;
            gv.DataBind();
        }
        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Handle")
            {
                // Fix: Use the CommandArgument property to retrieve the row index
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gv.Rows[rowIndex];
                int id = Convert.ToInt32(row.Cells[0].Text);
                TransactionHeader tx = transactionHeaderController.getTransactionHeaderById(id);
                if(tx.Status == "unhandled" || tx.Status == "Unhandled")
                {
                    tx.Status = "handled";
                    transactionHeaderController.updateTransactionHeader(tx);
                    refreshGrid();
                }
            }
        }
    }
}