using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DojoSurvey
{
    public class SurveyController : Controller{

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            ViewBag.Error = new List<string>();
            return View();
        }

        [HttpPost]
        [Route("info")]
        public IActionResult Info(string name, string location, string language, string comment){

            ViewBag.Error = new List<string>();

            if(name == null){
                ViewBag.Error.Add("You must enter your name");
            }

            if(location == null){
                ViewBag.Error.Add("Please select a location");
            }

            if(language == null){
                ViewBag.Error.Add("Please select a language");
            }

            if(comment == null){
                comment = "";
            }

            if(ViewBag.Error.Count > 0){
                return View("Index");
            }

            ViewBag.Name = name;
            ViewBag.Location = location;
            ViewBag.Language = language;
            ViewBag.Comment = comment;
            
            return View("Result");

        }

    }
}