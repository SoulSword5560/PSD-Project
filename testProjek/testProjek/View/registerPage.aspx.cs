using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.Factory;
using testProjek.handler;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.View
{
    public partial class registerPage : System.Web.UI.Page
    {
        userController userController = new userController();
        protected void Page_Load(object sender, EventArgs e)
        {
            userController.RedirectToUserHome(Session, Request, Response);
        }

        protected void RegBTN_Click(object sender, EventArgs e)
        {
            String username = nameTB.Text;
            String password = passTB.Text;
            String email = emailTB.Text;
            string conpassword = conPassTB.Text;
            string role = roleDDL.SelectedValue;
            string gender = genderDDL.SelectedValue;
            DateTime date = DateTime.Parse(dateTB.Text);
            errorMsg.ForeColor = System.Drawing.Color.Red;

            errorMsg.Text = userController.registerUser(username, password,conpassword, email,gender , role,date);
            Response.Redirect("~/View/loginPage.aspx");
        }
    }
}