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
        }


        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            string adminEmail = "admin@mail.ru";
            string adminPassword = "123456";

            // добавляем роли
            Role adminRole = new Role { Id = 1, NameOfRole = adminRoleName };
            Role userRole = new Role { Id = 2, NameOfRole = userRoleName };
            User adminUser = new User { Id = 1, FirstName = "Админ", LastName = "Админов", PhoneNumber = "89000000000", Login = "admin", Email = adminEmail, PasswordHashCode = adminPassword.GetHashCode().ToString(), RoleId = adminRole.Id };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            modelBuilder.Entity<User>().HasData(new User[] { adminUser });
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\;Database=ClusteringDB;Trusted_Connection=True;");
        }
    }
}
