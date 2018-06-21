using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Bank_Accounts.Models;
using Microsoft.AspNetCore.Http;

namespace Bank_Accounts.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        public HomeController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(NewUser user)
        {
            if(_context.users.SingleOrDefault(u => u.email == user.email) != null)
                ModelState.AddModelError("email", "Email already exists");
        
            if(ModelState.IsValid)
            {
                PasswordHasher<NewUser> pwhasher = new PasswordHasher<NewUser>();

                User createUser = new User()
                {
                    first_name = user.first_name,
                    last_name = user.last_name,
                    email = user.email,
                    password = pwhasher.HashPassword(user, user.password)
                };
                _context.users.Add(createUser);
                _context.SaveChanges();

                HttpContext.Session.SetInt32("id", (int)createUser.user_id);

                return Redirect($"/account/{user.user_id}");
            }

            return View("Index");
        }

        [HttpGet("login")]
        public IActionResult Login(LoginUser user)
        {
             if(_context.users.SingleOrDefault(u => u.email == user.log_email) == null)
                ModelState.AddModelError("log_email", "Invalid Email/Password");
            else
            {
                User checkUser = _context.users.SingleOrDefault(u => u.email == user.log_email);

                PasswordHasher<LoginUser> pwhasher = new PasswordHasher<LoginUser>();

                if(pwhasher.VerifyHashedPassword(user, checkUser.password, user.log_password) == 0)
                {
                    ModelState.AddModelError("log_password", "Invalid Email/Password");
                }
            }

            if(ModelState.IsValid)
            {
                User userLogin = _context.users.SingleOrDefault(u => u.email == user.log_email);

                HttpContext.Session.SetInt32("id", (int)userLogin.user_id);

                return Redirect($"/account/{HttpContext.Session.GetInt32("id")}");
            }

            return View("Index");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

    }
}
