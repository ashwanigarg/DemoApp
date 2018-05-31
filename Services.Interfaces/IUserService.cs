using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    [ServiceContract]
    public interface IUserService
    {
    //    int SaveUser(User user);
        [OperationContract]
        IList<User> GetUsers();

        [OperationContract]
        User RegisterUser(User user);

        [OperationContract]
        User Login(string id,string password);

        [OperationContract]
        bool IsEmailExist(string email);

    //    User GetUserById(int userId);
    }
}
