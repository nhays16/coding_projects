using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Wedding_Planner_EF.Models;

namespace Wedding_Planner_EF.Controllers
{
//    [Route("wedding")]
    public class WeddingController : Controller
    {
        public User LoggedIn
        {
            get { return _planner.users.SingleOrDefault(u => u.user_id == (int)HttpContext.Session.GetInt32("id"));}
        }
        private PlannerContext _planner;
        public WeddingController(PlannerContext planner)
        {
            _planner = planner;
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            if(LoggedIn == null)
                return RedirectToAction("Index", "Home");

            DashboardViewModel newmodel = new DashboardViewModel()
            {
                AllWeddings = _planner.weddings.Include(w => w.Attendees).ToList(),
                UserId = LoggedIn
            };
            return View(newmodel);
        }

        [HttpGet("wedding/{id}")]
        public IActionResult Info(int id)
        {
            return View(
                _planner.weddings 
                    .Include(w => w.Attendees)
                    .ThenInclude(a => a.Attendee)
                    .SingleOrDefault(w => w.wedding_id == id)
            );
        }

        [HttpPost("wedding/create")]
        public IActionResult CreateWed(Wedding wedding)
        {
            ViewBag.LoggedId = (int)HttpContext.Session.GetInt32("id");

            //DashboardViewModel newmodel = new DashboardViewModel()
            //{
            //    AllWeddings = _planner.weddings.Include(w => w.Attendees).ToList(),
            //    UserId = LoggedIn
            //};

            Wedding newWedding = new Wedding();
            if(ModelState.IsValid)
            {
                _planner.weddings.Add(newWedding);
                _planner.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            
            return View("Plan");
        }

        [HttpGet("wedding/plan")]
        public IActionResult PlanWedding()
        {
            return View("Plan");
        }

        [HttpGet("wedding/delete/{id}")]
        public IActionResult Delete(int id)
        {
            Wedding toDelete = _planner.weddings.SingleOrDefault(w => w.wedding_id == id && w.user_id == (int)HttpContext.Session.GetInt32("id"));
            if(toDelete == null)
                return RedirectToAction("Dashboard");
            
            _planner.weddings.Remove(toDelete);
            _planner.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/attend/{id}")]
        public IActionResult Attend(int id)
        {
            Wedding toAttend = _planner.weddings.SingleOrDefault(w => w.wedding_id == id);
            if(toAttend != null)
            {
                Guest newGuest =  new Guest()
                {
                    wedding_id = id,
                    user_id = (int)HttpContext.Session.GetInt32("id"),
                };
                _planner.guests.Add(newGuest);
                _planner.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

        [HttpGet("wedding/unattend/{id}")]
        public IActionResult UnAttend(int id)
        {
            Wedding toUnAttend = _planner.weddings.SingleOrDefault(w => w.wedding_id == id);
            if(toUnAttend != null)
            {
                Guest toRemove =  _planner.guests.SingleOrDefault(g => g.user_id == (int)HttpContext.Session.GetInt32("id") && g.wedding_id == id);
                
                _planner.guests.Remove(toRemove);
                _planner.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

    }
}