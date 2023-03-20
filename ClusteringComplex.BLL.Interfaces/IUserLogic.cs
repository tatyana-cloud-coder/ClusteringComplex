using ClusteringComplex.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddUser(User user);
        User GetNeedUser(string Login);

        IEnumerable<User> GetUsers();
    }
}
