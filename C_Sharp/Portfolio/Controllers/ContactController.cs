using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio
{
    public class ContactController : Controller{
        
        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View();
        }
    }
}