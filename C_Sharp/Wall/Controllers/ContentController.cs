using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Wall.Models;


namespace Wall.Controllers
{
    public class ContentController : Controller
    {
              
        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {           
            if(HttpContext.Session.GetInt32("id") == null)
                return RedirectToAction("Index", "Home");

            ViewBag.Messages = AllMessages();
            ViewBag.Comments = AllComments();
            ViewBag.User = DbConnector.Query($"SELECT first_name FROM users WHERE users.id = {(int)HttpContext.Session.GetInt32("id")}")[0];  
            return View();
        }


        [HttpPost("messages/create")]
        public IActionResult CreateMessage(ContentModels contentmodel)
        {
            if(ModelState.IsValid)
            {
                string createM = $@"INSERT INTO messages (message, user_id, created_at, updated_at)
                    VALUES ('{contentmodel.MessagePost.message}', {(int)HttpContext.Session.GetInt32("id")}, NOW(), NOW())";
                DbConnector.Execute(createM);
                return RedirectToAction("Dashboard");
            }

            else
            {
                return View("Dashboard");
            }
        }


        [HttpPost("comments/create")]
        public IActionResult CreateComment(ContentModels contentmodel)
        {
            if(ModelState.IsValid)
            {
                string createC = $@"INSERT INTO comments (comment, message_id, user_id, created_at, updated_at)
                    VALUES ('{contentmodel.CommentPost.comment}', '{contentmodel.CommentPost.messageID}',{(int)HttpContext.Session.GetInt32("id")}, NOW(), NOW())";
                DbConnector.Execute(createC);
                return RedirectToAction("Dashboard");
            }

            else
            {
                return View("Dashboard");
            }
        }


        public List<Dictionary<string, object>> AllMessages()
        {
            string allMessages = @"SELECT messages.id AS message_id, messages.message, messages.created_at, users.first_name, users.last_name
                FROM messages JOIN users ON messages.user_id = users.id";
            return DbConnector.Query(allMessages);
        }

        public List<Dictionary<string, object>> AllComments()
        {
            string allComments = @"SELECT comments.id AS comment_id, comments.comment, comments.created_at, comments.message_id, users.first_name, users.last_name
                FROM comments JOIN messages ON comments.message_id = messages.id
                JOIN users ON comments.user_id = users.id";
            return DbConnector.Query(allComments);
        }
    }
}
