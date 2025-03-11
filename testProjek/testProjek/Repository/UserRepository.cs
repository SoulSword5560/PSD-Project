using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testProjek.Factory;
using testProjek.Model;

namespace testProjek.Repository
{
    
    public class UserRepository
    {
        public static void insertNewUser(string username, string password, string email, string gender, string role, DateTime date)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            User user = UserFactory.createNewUser(username, password, email, gender, role, date);
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static User getUser(string username, string password)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            var user = (from x in db.Users where x.UserName == username && x.UserPassword == password select x).FirstOrDefault();
            return user;
        }

    }
}