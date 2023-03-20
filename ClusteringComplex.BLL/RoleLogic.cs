using ClusteringComplex.BLL.Interfaces;
using ClusteringComplex.DAO;
using ClusteringComplex.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.BLL
{
    public class RoleLogic : IRoleLogic
    {

        private ApplicationContext context; 

        public RoleLogic ()
        {
            context = new ApplicationContext();
        }
        public void AddRole(Role role)
        {
            context.Roles.Add(role);
            context.SaveChanges();  
        }

        public void AddUserToRole (User user, Role role)
        {
            user.Roles.Add(role);
            context.SaveChanges();
        }
    }
}
