using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojo_League.Models;
using Dojo_League.Factory;

namespace Dojo_League.Controllers
{
    public class NinjaController : Controller
    {
        private readonly NinjaFactory ninjaFactory;

        public NinjaController(){
            ninjaFactory = new NinjaFactory();
        }

        [HttpGet("ninjas")]
        public IActionResult Ninjas()
        {
            ViewBag.AllNinjas = 
            return View();
        }

        [HttpPost("createNinja")]
        public IActionResult createNinja(Ninja ninja)
        {
            ninjaFactory.AddNinja(ninja);
            return RedirectToAction("Ninjas");
        }
        
        [HttpPost("banish")]
        public IActionResult Banish()
        {
            
        }

        [HttpPost("recruit")]
        public IActionResult Recruit()
        {
            
        }

        [HttpGet("ninja/{id}")]
        public IActionResult NinjaInfo()
        {
            ViewBag.Ninja
            return View();
        }
    }
}
