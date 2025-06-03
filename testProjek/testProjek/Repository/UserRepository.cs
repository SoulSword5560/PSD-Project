using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Factory;
using testProjek.handler;
using testProjek.Model;

namespace testProjek.Repository
{
    
    public class UserRepository
    {
        public  void insertNewUser(User user)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User getUser(string username, string password)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            var user = (from x in db.Users where x.UserName == username && x.UserPassword == password select x).FirstOrDefault();
            return user;
        }
        public User getUserData(int userid)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            return db.Users.FirstOrDefault(u => u.UserID == userid);
        }

        public void updateUser(int userId, string username, string email, string password)
        {
            using (var db = new databaseEntities1())
            {
                var user = db.Users.FirstOrDefault(u => u.UserID == userId);
                if(username == "")
                {
                    username = user.UserName;
                }
                else if(email == "")
                {
                    email = user.UserEmail;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    var oldPassword = user.UserPassword;
                    password = oldPassword;
                }
                if (user != null)
                {
                    user.UserName = username;
                    user.UserEmail = email;
                    user.UserPassword = password;
                    db.SaveChanges();
                }
            }
        }
    }
}