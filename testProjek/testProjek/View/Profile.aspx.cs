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

            string role;
            if (Session["role"] != null)
            {
                role = Session["role"].ToString();
            }
            else
            {
                role = Request.Cookies["user"]["role"].ToString();
            }
            if (role == null)
            {
                Response.Redirect("~/View/loginPage.aspx");
                return;
            }

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
            string userIdd;
            if (Session["id"] != null)
            {
                userIdd = Session["id"].ToString();
            }
            else
            {
                userIdd = Request.Cookies["user"]["id"].ToString();
            }
            int UserId = Convert.ToInt32(userIdd);
            if (!IsPostBack)
            {
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