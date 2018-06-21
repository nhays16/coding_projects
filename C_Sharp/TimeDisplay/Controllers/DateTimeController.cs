using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TimeDisplay{

    public class DateTimeController : Controller{

        DateTime CurrentTime = DateTime.Now;

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

    }
}