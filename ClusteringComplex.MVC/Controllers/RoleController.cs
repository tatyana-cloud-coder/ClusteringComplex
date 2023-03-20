using ClusteringComplex.DAO;
using ClusteringComplex.Entities;
using ClusteringComplex.Integration;
using ClusteringComplex.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClusteringComplex.BLL;

namespace ClusteringComplex.MVC.Controllers
{
    public class RoleController : Controller
    {
        private readonly ILogger<RoleController> _logger;
        private readonly RoleLogic roleLogic;

        public RoleController(ILogger<RoleController> logger)
        {
            _logger = logger;
            roleLogic = new RoleLogic();
        }


        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            roleLogic.AddRole(role);
            return View();
        }




        public IActionResult Privacy()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // создаем два объекта User
                User user1 = new User { FirstName = "Tom", LastName = "abd" };
              //  User user2 = new User { Name = "Alice", Age = 26 };

                // добавляем их в бд
                db.Users.Add(user1);
             //   db.Users.Add(user2);
                db.SaveChanges();
                Console.WriteLine("Объекты успешно сохранены");

                // получаем объекты из бд и выводим на консоль
            }
            var googleCollab = new GoogleCollabIntegration();
            var a = googleCollab.Test(5);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
