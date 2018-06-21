using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Bank_Accounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Bank_Accounts.Controllers
{
    public class WithdrawalController : Controller
    {
        public User LoggedIn
        {
            get { return _context.users.SingleOrDefault(u => u.user_id == (int)HttpContext.Session.GetInt32("id"));}
        }

        private MyContext _context;
        public WithdrawalController(MyContext context)
        {
            _context = context;
        }

        [HttpGet("account/{id}")]
        public IActionResult Account(int id)
        {
            int? userId = HttpContext.Session.GetInt32("id");

            if(id != userId)
            {
                return RedirectToAction("Login", "Home");
            }

            User user = _context.users.Include(u => u.withdrawals).Where(u => u.user_id == userId).SingleOrDefault();
            
            if(user.withdrawals != null)
            {
                user.withdrawals = user.withdrawals.OrderByDescending(w => w.created_at).ToList();
            }
            ViewBag.Info = user;
            return View();
        }

        [HttpPost("transaction")]
        public IActionResult Transaction(float amount)
        {
            int? userId = HttpContext.Session.GetInt32("id");

            User user = _context.users.Where(u => u.user_id == userId).SingleOrDefault();

            if(amount < 0 && ((amount * -1) > user.balance))
            {
                TempData["Error"] = "Insufficient funds";
            }
            
            else{
                Withdrawal deduct = new Withdrawal{
                    amount = amount,
                    user = user,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                user.balance += amount;
                _context.withdrawals.Add(deduct);
                _context.SaveChanges();
            }
            return RedirectToAction("Account");
        }
    }
}