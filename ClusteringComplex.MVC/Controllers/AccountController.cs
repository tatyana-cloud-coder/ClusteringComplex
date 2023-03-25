﻿using ClusteringComplex.DAO;
using ClusteringComplex.Entities;
using ClusteringComplex.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClusteringComplex.MVC.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationContext _context;
        public AccountController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Введены неккоректные данные!");
                return View(model);
            }
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Login == model.Login);
            if (user!=null)
            {
                ModelState.AddModelError("", "Пользователь с таким логином уже есть");
                return View(model);
            }
            user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                MiddleName = model.MiddleName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                Login = model.Login,
                PasswordHashCode = Coder.HashPassword(model.Password)
            };
            Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.NameOfRole == "user");
            if (userRole == null)
            {
                ModelState.AddModelError("", "Такой роли нет в системе");
                return View(model);
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login", "Account");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Введены некорректные данные!");
                return View(model);
            }
            User user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == model.Login);

            if (user==null)
            {
                ModelState.AddModelError("", "Такого пользователя нет!");
                return View(model);
            }

            if (!Coder.VerifyHashedPassword(user.PasswordHashCode, model.Password))
            {
                ModelState.AddModelError("", "Хеш пароля не совпадает с введенной строкой!");
                return View(model);
            }
            await Authenticate(user); // аутентификация
            return RedirectToAction("MainMenu", "Complex");
        }
        private async Task Authenticate(User user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.NameOfRole)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
            