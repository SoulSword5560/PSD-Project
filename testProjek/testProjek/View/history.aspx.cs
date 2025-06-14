﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.Report;

namespace testProjek.View
{
    public partial class history : System.Web.UI.Page
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
            if (userId == null)
            {
                Response.Redirect("~/View/loginPage.aspx");
                return;
            }
            if (!IsPostBack)
            {
                refreshGrid();
            }      
        }

        public void refreshGrid()
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
            List<object> list = controller.getHistoryByUser(userId);
            if (list != null && list.Count > 0)
            {
                GridView1.DataSource = list;
                GridView1.DataBind();
                Label1.Text = ""; 
            }
            else
            {
                Label1.Text = "No History Available.";
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }

        protected void detailBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string transactionId = GridView1.DataKeys[row.RowIndex].Value.ToString();
            Response.Redirect("~/View/historyDetail.aspx?transactionId=" + transactionId);
        }
    }
}