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
        public  void insertNewUser(User user)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            db.Users.Add(user);
            db.SaveChanges();
        }

        public  User getUser(string username, string password)
        {
            databaseEntities1 db = databaseSingleton.getInstance();
            var user = (from x in db.Users where x.UserName == username && x.UserPassword == password select x).FirstOrDefault();
            return user;
        }

    }
}