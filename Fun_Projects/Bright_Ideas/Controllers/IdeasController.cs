using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BrightIdeas.Models;
using Microsoft.EntityFrameworkCore;

namespace BrightIdeas.Controllers
{
    public class IdeasController : Controller
    {

        public User LoggedIn
        {
            get {return _context.users.SingleOrDefault(u => u.user_id == (int)HttpContext.Session.GetInt32("id"));}
        }

        private MyContext _context;
        public IdeasController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("bright_ideas")]
        public IActionResult Dashboard()
        {
            if(LoggedIn == null)
                return RedirectToAction("Index", "Home");

            DashboardModel viewModel = new DashboardModel()
            {
                PopularIdeas = _context.ideas
                    .Include(i => i.creator)
                    .Include(i => i.likes)
                    .OrderByDescending(i => i.likes.Count).Take(5).ToList(),
                LoggedUser = LoggedIn,
                NewIdea = null
            };
            return View(viewModel);
        }

        [HttpPost("create")]
        public IActionResult Create(DashboardModel model)
        {
            Idea newIdea = model.NewIdea;
            if(ModelState.IsValid)
            {
                _context.ideas.Add(newIdea);
                _context.SaveChanges();
                return RedirectToAction("Dashboard");
            }

            DashboardModel viewModel = new DashboardModel()
            {
                PopularIdeas = _context.ideas
                    .Include(i => i.creator)
                    .Include(i => i.likes)
                    .OrderByDescending(i => i.likes.Count).Take(5).ToList(),
                LoggedUser = LoggedIn,
                NewIdea = newIdea
            };

            return View("Index", viewModel);
        }

        [HttpGet("users/{id}")]
        public IActionResult UserProfile(int id)
        {
            return View(
                _context.users
                    .Include(u => u.MyIdeas)
                    .Include(u => u.MyLikes)
                    .SingleOrDefault(u => u.user_id == id)
            );
        }

        [HttpGet("bright_ideas/{id}")]
        public IActionResult Info(int id)
        {
            return View(
                _context.ideas
                    .Include(i => i.creator)
                    .Include(i => i.likes)
                    .ThenInclude(l => l.liker)
                    .SingleOrDefault(i => i.idea_id == id)
            );
        }

        [HttpGet("bright_ideas/delete/{id}")]
        public IActionResult Delete(int id)
        {
            Idea toDelete = _context.ideas.SingleOrDefault(i => i.idea_id == id && i.user_id == (int)HttpContext.Session.GetInt32("id"));
            if(toDelete == null)
                return RedirectToAction("Dashboard");
        
            _context.ideas.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        [HttpGet("like/{id}")]
        public IActionResult Like(int id)
        {
            Idea toLike = _context.ideas.SingleOrDefault(i => i.idea_id == id);
            if(toLike != null)
            {
                Like newLike = new Like()
                {
                    idea_id = id,
                    user_id = (int)HttpContext.Session.GetInt32("id")
                };
                _context.likes.Add(newLike);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }
    }
}