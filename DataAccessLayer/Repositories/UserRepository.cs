using Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Extensions;
namespace DataAccessLayer
{
    public class UserRepository : Repository<User>
    {
        private DbContext _context;
        public UserRepository(DbContext context)
            : base(context)
        {
            _context = context;
        }


        public IList<User> GetUsers()
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandText = "exec [dbo].[sp_GetUsers]";

                return this.ToList(command).ToList();
            }
        }

        public User CreateUser(User user)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UserRegistration";

                command.Parameters.Add(command.CreateParameter("@FirstName",user.FirstName));
                command.Parameters.Add(command.CreateParameter("@LastName", user.LastName));
                command.Parameters.Add(command.CreateParameter("@UserName", user.UserName));
                command.Parameters.Add(command.CreateParameter("@Password", user.Password));
                command.Parameters.Add(command.CreateParameter("@Roleid", user.Roleid));

                return this.ToList(command).FirstOrDefault();

              
            }
           
        }


        public User LoginUser(string id, string password)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_UserLogin";

                command.Parameters.Add(command.CreateParameter("@UserName", id));
                command.Parameters.Add(command.CreateParameter("@Password", password));

                return this.ToList(command).FirstOrDefault();
            }
        }


        public User GetUserByEmail(string email)
        {
            using (var command = _context.CreateCommand())
            {
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetUserByEmail";
                command.Parameters.Add(command.CreateParameter("@Email", email));
                return this.ToList(command).FirstOrDefault();
            }
        }

        
    }
}
