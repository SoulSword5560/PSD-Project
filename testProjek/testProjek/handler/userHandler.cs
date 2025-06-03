using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;
using testProjek.Factory;
using testProjek.Model;
using testProjek.Repository;

namespace testProjek.handler
{
    public class userHandler
    {
        UserRepository userRepository = new UserRepository();
        UserFactory userFactory = new UserFactory();

        public User getUser(string username, string password)
        {
            return userRepository.getUser(username, password);
        }
        
        public User getUserData(int userid)
        {
            return userRepository.getUserData(userid);
        }

        public void registerUser(string username, string password, string email, string gender, string role, DateTime date)
        {
            User user = userFactory.createNewUser(username, password,email,gender,role,date);
            userRepository.insertNewUser(user);
        }

       public void UpdateUser(int userid, string username, string email, string password)
        {
            userRepository.updateUser(userid, username, email, password);
        }
    }
}
