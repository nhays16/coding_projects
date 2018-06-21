using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lost_in_the_Woods.Models;
using Lost_in_the_Woods.Factory;

namespace Lost_in_the_Woods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;

        public HomeController(){
            trailFactory = new TrailFactory();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllTrails = trailFactory.GetAllTrails();
            return View();
        }


        [HttpGet("info/{id}")]
        public IActionResult Info(int id)
        {
            ViewBag.Trail = trailFactory.GetTrail(id);
            return View();
        }


        [HttpPost("create")]
        public IActionResult Create(Trail trail)
        {
            trailFactory.AddTrail(trail);
            return RedirectToAction("Index");
        }


        [HttpGet("add")]
        public IActionResult Add()
        {
            return View("Add");
        }
    }
}
