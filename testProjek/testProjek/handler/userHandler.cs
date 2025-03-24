using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public void registerUser(string username, string password, string email, string gender, string role, DateTime date)
        {
            User user = userFactory.createNewUser(username, password,email,gender,role,date);
            userRepository.insertNewUser(user);
        }
    }
}