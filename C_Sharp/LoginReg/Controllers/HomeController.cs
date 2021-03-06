﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LoginReg.Models;


namespace LoginReg.Controllers
{
    public class HomeController : Controller
    {


        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("signup")]
        public IActionResult LoginView()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> pwhasher = new PasswordHasher<User>();

                string hashedPW = pwhasher.HashPassword(user, user.password);

                string createUser = $@"INSERT INTO users (first_name, last_name, email, password, created_at, updated_at)
                    VALUES ('{user.first_name}', '{user.last_name}', '{user.email}', '{hashedPW}', NOW(), NOW())";
                DbConnector.Execute(createUser);
                string query = $"SELECT id FROM users WHERE email = '{user.email}'";
                HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(query)[0]["id"]));

                return RedirectToAction("Success");
            }
            else{
                return View("Index");
            }
        }

        [HttpPost("login")]
        public IActionResult Login(LogUser user)
        {
            if(ModelState.IsValid)
            {
                string verifyEmail = $"SELECT * FROM users WHERE email = '{user.email}'";
                List<Dictionary<string, object>> userfromDB = DbConnector.Query(verifyEmail);
                HttpContext.Session.SetInt32("id", Convert.ToInt32(DbConnector.Query(verifyEmail)[0]["id"]));

                if(userfromDB.Count < 1)
                {
                    ModelState.AddModelError("email", "Invalid Email/Password");;;
                }
                else{
                    Dictionary<string, object> actualUser = userfromDB.First();

                    PasswordHasher<LogUser> hasher = new PasswordHasher<LogUser>();
                    PasswordVerificationResult results = hasher.VerifyHashedPassword(user, (string)actualUser["password"], user.password);
                    if(results == PasswordVerificationResult.Failed)
                    {
                        ModelState.AddModelError("email", "Invalid Email/Password");
                    }
                }            
            }

            if(ModelState.IsValid){
                return RedirectToAction("Success");
            }
            else{
                return View("LoginView");
            }
        }

        [HttpGet("success")]
        public IActionResult Success()
        {
            int? userOrNull = HttpContext.Session.GetInt32("id");
            if(userOrNull == null)
                return RedirectToAction("Index");
            
            return View();
        }
    }
}
