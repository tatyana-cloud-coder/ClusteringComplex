using ClusteringComplex.BLL;
using ClusteringComplex.Entities;
using ClusteringComplex.Helpers.Extensions;
using ClusteringComplex.Integration;
using ClusteringComplex.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClusteringComplex.MVC.Controllers
{
    public class ComplexController : Controller
    {
        private readonly GreeterIntegration _greeterIntegration;

        private readonly VKPageLogic _vkPageLogic;
        public ComplexController()
        {
            _greeterIntegration = new GreeterIntegration();
            _vkPageLogic = new VKPageLogic();
        }
        [HttpGet]
        public IActionResult MainMenu()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActionGetUserFriends()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActionBuiltPartition()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActionBuiltPartitionContent()
        {
           return View();
        }

        [HttpGet]
        public IActionResult ActionShowParallel()
        {
            return View();
        }


        [Authorize(Roles = "admin, user")]
        [HttpPost]
        public IActionResult GetInfoUserFriends(VKPage vkPage)
        {
            var result = _vkPageLogic.GetInfoUserFriends(vkPage);
            return View("UserFriends", result);
        }


        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult BuiltInfoMapPartition(VKPage vkPage)
        {
            var result = _vkPageLogic.BuildInfoMapPartition(vkPage);

            return View("InfoMapPartition", result);
        }

        [HttpPost]
        public IActionResult BuiltInfoMapPartitionContent(VKPage vkPage)
        {
            var result = _vkPageLogic.BuiltInfoMapPartitionContent(vkPage);
            return View("InfoMapPartition", result);
        }


 

        [HttpPost]
        public async Task<IActionResult> ShowParallel(VKPage vkPage)
        {

            ParallelM model = await _vkPageLogic.ShowParallel(vkPage);
            return View("ShowParallel", model);
        }
    }
}
