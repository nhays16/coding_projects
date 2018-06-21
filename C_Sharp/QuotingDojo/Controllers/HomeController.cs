using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;

namespace QuotingDojo.Controllers
{
    public class HomeController : Controller
    {
              
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {           
            if(TempData["Error"] != null){
                ViewBag.Error = TempData["Error"];
            }       
            return View();
        }


        [HttpPost]
        [Route("/quotes")]
        public IActionResult CreateQuote(string name, string content)
        {
            if(name == null || content == null)
            {
                TempData["Error"] = "Please make sure both fields are completed";
                return RedirectToAction("Index");
            }

            else
            {
                string query = $"INSERT INTO quotes(content, posted_by, created_at, updated_at) VALUES('{content}', '{name}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Quotes");
            }
        }


        [HttpGet]
        [Route("/quotes")]
        public IActionResult Quotes()
        {
            string queryAll = "SELECT * FROM quotes";
            var quotes = DbConnector.Query(queryAll);

            quotes = quotes.OrderByDescending((quote) => quote["created_at"]).ToList();      
            
            foreach(var quote in quotes){
                DateTime created = (DateTime)quote["created_at"];
                string formatted_created = String.Format("{0:h:mm tt MMMM d yyyy}", created);
                quote["created_at"] = formatted_created;
            }

            ViewBag.AllQuotes = quotes;

            return View();
        }
    }
}
