using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using testProjek.Model;

namespace testProjek.Factory
{
    public class UserFactory
    {
        public static User createNewUser(string username, string password, string email,string gender, string role, DateTime date)
        {
            User user = new User();
            user.UserName = username;
            user.UserPassword = password;
            user.UserEmail = email;
            user.UserGender = gender;
            user.UserRole = role;
            user.UserDOB = date;
            return user;
        }
    }
}