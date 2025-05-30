using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using testProjek.handler;
using testProjek.Model;

namespace testProjek.Controller
{
    public class userController
    {
        userHandler userHandler = new userHandler();
        public  bool IsUserAuthenticated(HttpSessionState session, HttpRequest request)
        {
            return session["user"] != null || request.Cookies["user"] != null;
        }

        public  void RedirectIfNotAuthenticated(HttpSessionState session, HttpRequest request, HttpResponse response)
        {
            if (!IsUserAuthenticated(session, request))
            {
                response.Redirect("loginPage.aspx");
            }
        }

        public  string GetUserRole(HttpSessionState session, HttpRequest request)
        {
            string roleFromSession = session["role"]?.ToString();
            string roleFromCookie = request.Cookies["user"]?["role"];
            return roleFromSession ?? roleFromCookie;
        }

        public  void RedirectToUserHome(HttpSessionState session, HttpRequest request, HttpResponse response)
        {
            if (IsUserAuthenticated(session, request))
            {
                string role = GetUserRole(session, request);

                if (role == "Customer")
                {
                    response.Redirect("homeCustomer.aspx");
                }
                else
                {
                    response.Redirect("homeAdmin.aspx");
                }
            }
        }

        public string registerUser(string username, string password,string conpassword, string email, string gender, string role, DateTime date)
        {
            DateTime now = DateTime.Now;
            if (!Regex.IsMatch(username, @"^[A-Za-z ]{5,30}$"))
            {
                return "username wrong";
            }
            if (!email.Contains("@") || email == " ")
            {
                return "email wrong";
            }
            if (password.Length < 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit))
            {
                return "password wrong";
            }
            if (gender == " ")
            {
                return "gender wrong";
            }
            if (conpassword != password)
            {
                return "password not match";
            }
            if (role == "")
            {
                return "role wrong" ;
            }
            if (date > now)
            {
                return "datetime wrong";
            }
            userHandler.registerUser(username, password, email, gender, role, date);
            return "";
        }

        public User validateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }

            return userHandler.getUser(username, password);
        }
        public class UserController
        {
            public static string UpdateProfile(int userId, string username, string password, string email, string gender, string role, DateTime dob,
                                               string oldPassword, string newPassword, string confirmPassword)
            {
                return userHandler.UpdateUser(userId, username, password, email, gender, role, dob,
                                              oldPassword, newPassword, confirmPassword);
            }
        }

    }
}