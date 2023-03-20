using Microsoft.AspNetCore.Mvc;
using System;
using ClusteringComplex.DAO;
using ClusteringComplex.Entities;
using ClusteringComplex.Integration;
using ClusteringComplex.MVC.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ClusteringComplex.BLL;

namespace ClusteringComplex.MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<RoleController> _logger;
        private readonly UserLogic userLogic;

        public UserController(ILogger<RoleController> logger)
        {
            _logger = logger;
            userLogic = new UserLogic();
        }


        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            userLogic.AddUser(user);
            return View();
        }

        [HttpGet]
        public IActionResult GetProfile()
        {
            return View();
        }


        [HttpGet]
        public IActionResult SignIn()
        {

            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User user)
        {
           
            User MyProfile = userLogic.GetNeedUser(user.Login);
            TempData["FirstName"] = MyProfile.FirstName;
            TempData["LastName"] = MyProfile.LastName;
            TempData["PhoneNumber"] = MyProfile.PhoneNumber;
            TempData["Login"] = user.Login;
            return RedirectToAction("GetProfile");
        }

        [HttpGet]
        public IActionResult GetUsersByAdmin()
        {
            var users = userLogic.GetUsers();
            return View(users);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {

            var users = userLogic.GetUsers();
            return View(users);
        }


    }
}
