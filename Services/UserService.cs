using DataAccessLayer;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Services.Interfaces;
using System.ServiceModel.Activation;

namespace Services
{
    public class UserService : IUserService
    {
        private IConnectionFactory connectionFactory;

        public IList<User> GetUsers()
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            return userRep.GetUsers();
        }

        public User RegisterUser(User user)
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            return userRep.CreateUser(user);
        }


        public User Login(string id, string password)
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            return userRep.LoginUser(id, password);
        }

        public bool IsEmailExist(string email)
        {
            connectionFactory = ConnectionHelper.GetConnection();

            var context = new DbContext(connectionFactory);

            var userRep = new UserRepository(context);

            var user = userRep.GetUserByEmail(email);
            return (user != null);

        }
    }
}
