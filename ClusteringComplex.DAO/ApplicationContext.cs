using ClusteringComplex.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusteringComplex.DAO
{
    public class ApplicationContext :DbContext
    {
     public DbSet<User> Users { get; set; }
     public DbSet<Role> Roles { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\;Database=ClusteringDB;Trusted_Connection=True;");
        }
    }
}
