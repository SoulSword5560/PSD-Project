using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Controller;
using testProjek.Model;

namespace testProjek.View
{
    public partial class Profile : System.Web.UI.Page
    {
        userController userController = new userController();
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["role"] == null)
            {
                Response.Redirect("~/View/loginPage.aspx");
                return;
            }

            string role = Session["role"].ToString();

            if (role == "Admin")
            {
                this.MasterPageFile = "~/View/navbarAdmin.Master";
            }
            else if (role == "Customer")
            {
                this.MasterPageFile = "~/View/navbarCustomer.Master";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] == null)
            {
                Response.Redirect("~/View/loginPage.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int UserId = (int)Session["id"];
                User user = userController.getUserData(UserId);
                if (user != null)
                {
                    usnTxt.Text = "Username: " + user.UserName;
                    emailTxt.Text = "Email: " + user.UserEmail;
                    genderTxt.Text = "Gender: " + user.UserGender;
                    roleTxt.Text = "Role: " + user.UserRole;
                    dobTxt.Text = "Date of Birth: " + user.UserDOB.ToString("dd MMM yyyy");
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/View/loginPage.aspx");
                return;
            }
            int userId = (int)Session["UserID"];
            User user = userController.getUserData(userId);

            if (user == null)
            {
                lblMessage.Text = "User not found.";
                return;
            }
            string newUsername = txtUsername.Text.Trim();
            string newEmail = txtEmail.Text.Trim();
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            if (!string.IsNullOrWhiteSpace(oldPassword) || !string.IsNullOrWhiteSpace(newPassword) || !string.IsNullOrWhiteSpace(confirmPassword))
            {
                if (string.IsNullOrWhiteSpace(oldPassword) || string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
                {
                    lblMessage.Text = "Fill all password colomn!";
                    return;
                }
                if (user.UserPassword != oldPassword)
                {
                    lblMessage.Text = "Old Password isn't match.";
                    return;
                }
                user.UserPassword = newPassword;
            }
            user.UserName = newUsername;
            user.UserEmail = newEmail;
            userController.updateUser(userId, newUsername, newEmail, newPassword, confirmPassword);
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = "Profil updated.";
            usnTxt.Text = "Username: " + user.UserName;
            emailTxt.Text = "Email: " + user.UserEmail;
        }
    }
}