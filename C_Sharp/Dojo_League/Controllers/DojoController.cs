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
    public class DojoController : Controller
    {
        private readonly DojoFactory dojoFactory;

        public DojoController(){
            dojoFactory = new DojoFactory();
        }

        [HttpGet("dojos")]
        public IActionResult Dojos()
        {
            return View();
        }

        [HttpPost("createDojo")]
        public IActionResult createDojo(Dojo dojo)
        {
            dojoFactory.AddDojo(dojo);
            return RedirectToAction("Dojos");
        }
        
        [HttpPost("dojos/{id}")]
        public IActionResult DojoInfo(int id)
        {
            
        }
    }
}
