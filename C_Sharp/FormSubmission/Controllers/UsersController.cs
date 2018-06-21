using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using FormSubmission.Models;

namespace FormSubmission.Controllers
{
    public class UsersController : Controller
    {

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        [Route("/create")]
        public IActionResult Method(string FirstName, string LastName, int Age, string Email, string Password)
        {
            User newUser = new User{

                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Email = Email,
                Password = Password
            };
            if(TryValidateModel(newUser) == false)
            {
                ViewBag.Errors = ModelState.Values;
                return View("Index");
            }
            else{
                return RedirectToAction("Success");
            }
        }

        [HttpGet]
        [Route("/success")]
        public IActionResult Success(){
            return View();
        }

    }
}
