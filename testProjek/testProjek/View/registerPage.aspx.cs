using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Factory;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.View
{
    public partial class registerPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user"] != null)
            {
                if (Session["role"]?.ToString() == "Customer" || Request.Cookies["user"]["role"] == "Customer")
                {
                    Response.Redirect("homeCustomer.aspx");
                }
                else
                {
                    Response.Redirect("homeAdmin.aspx");
                }
            }
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

            if(!Regex.IsMatch(username, @"^[A-Za-z ]{5,30}$"))
            {
                nameLbl.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "invalid data";
                return;
            }
            if(!email.Contains("@") || email == " ")
            {
                passLbl.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "invalid data";
                return;
            }
            if (password.Length < 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                passLbl.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "invalid data";
                return;
            }
            if(gender == " ")
            {
                genderLbl.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "invalid data";
                return;
            }
            if(conpassword != password)
            {
                conPassLbl.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "invalid data";
                return;
            }
            if (role == "")
            {
                roleLbl.ForeColor = System.Drawing.Color.Red;
                errorMsg.Text = "invalid data";
                return;
            }

            UserRepository.insertNewUser(username, password, email, gender, role, date);
            Response.Redirect("~/View/loginPage.aspx");
        }
    }
}