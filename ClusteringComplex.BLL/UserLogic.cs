using ClusteringComplex.BLL.Interfaces;
using ClusteringComplex.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClusteringComplex.DAO;

namespace ClusteringComplex.BLL
{
    public class UserLogic :IUserLogic
    {
        private ApplicationContext context; 

        public UserLogic()
        {
            context = new ApplicationContext();
        }
        public void AddUser(User user)
        {
            user.PasswordHashCode = user.PasswordHashCode.GetHashCode().ToString();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetNeedUser (string Login)
        {
            return context.Users.FirstOrDefault(x => String.Equals(x.Login, Login));
        }


        public void AddRoleToUser (Role role, User user)
        {
            user.Roles.Add(role);
            context.SaveChanges();
        }

        public IEnumerable <User> GetUsers()
        {
            return context.Users;
        }
    }
}
