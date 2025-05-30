using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using testProjek.Model;

namespace testProjek.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Cek apakah user login
            if (Session["UserRole"] == null)
            {
                Response.Redirect("loginPage.aspx");
                return;
            }

            string role = Session["UserRole"].ToString();

            if (role == "Admin")
            {
                this.MasterPageFile = "~/View/navbarAdmin.Master";
            }
            else if (role == "Customer")
            {
                this.MasterPageFile = "~/View/navbarCustomer.Master";
            }
            else
            {
                // Kalau role tidak jelas, redirect ke login
                Response.Redirect("loginPage.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("loginPage.aspx");
                return;
            }
            if (!IsPostBack)
            {
                int UserId = (int)Session["UserID"];
                using (var db = new databaseEntities1())
                {
                    var user = db.Users.FirstOrDefault(u => u.UserID == UserId);
                    if (user != null)
                    {
                        txtUsername.Text = user.UserName;
                        txtUseremail.Text = user.UserEmail;
                        txtPassword.Text = user.UserPassword;
                        ddlGender.SelectedValue = user.UserGender;
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string gender = ddlGender.SelectedValue;

            string oldPwd = txtOldPassword.Text;
            string newPwd = txtNewPassword.Text;
            string confirmPwd = txtConfirmPassword.Text;

            if (username.Length < 5 || username.Length > 30 || !Regex.IsMatch(username, @"^[A-Za-z ]+$"))
            {
                lblMessage.Text = "Invalid username.";
                return;
            }

            if (!email.Contains("@"))
            {
                lblMessage.Text = "Invalid email.";
                return;
            }

            if (password.Length < 8 || !Regex.IsMatch(password, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$"))
            {
                lblMessage.Text = "Invalid current password.";
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                lblMessage.Text = "Please choose a gender.";
                return;
            }

            if (!string.IsNullOrEmpty(newPwd))
            {
                if (oldPwd != password)
                {
                    lblMessage.Text = "Old password doesn't match current password.";
                    return;
                }

                if (newPwd.Length < 8 || !Regex.IsMatch(newPwd, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$"))
                {
                    lblMessage.Text = "New password must be at least 8 characters and alphanumeric.";
                    return;
                }

                if (confirmPwd != newPwd)
                {
                    lblMessage.Text = "Confirmation password doesn't match new password.";
                    return;
                }

                password = newPwd;
            }

            int userId = (int)Session["UserID"];
            using (var db = new databaseEntities1())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                if (user != null)
                {
                    user.UserName = username;
                    user.UserEmail = email;
                    user.UserPassword = password;
                    user.UserGender = gender;
                    db.SaveChanges();
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = "Profile updated successfully.";
                }
            }
        }
    }
}