using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio
{
    public class HomeController : Controller{

        [HttpGet]
        [Route("home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}