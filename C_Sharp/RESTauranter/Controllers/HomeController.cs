using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private ReviewContext _review;
        public HomeController(ReviewContext review)
        {
            _review = review;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("create")]
        public IActionResult Create(Review review)
        {
            
            _review.reviews.Add(review);
            _review.SaveChanges();         
            return RedirectToAction("Reviews");
        }

        [HttpGet("reviews")]
        public IActionResult Reviews()
        {
            List<Review> AllReviews = _review.reviews.ToList();
            ViewBag.AllReviews = AllReviews;
            return View();
        }
    }
}
