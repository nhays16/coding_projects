using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Portfolio
{
    public class ProjectsController : Controller{
        
        [HttpGet]
        [Route("projects")]
        public IActionResult Projects()
        {
            return View();
        }
    }
}