using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller{

        [HttpGet]
        [Route("")]
        public IActionResult Index(){

            if(HttpContext.Session.GetObjectFromJson<MyDojodachiInfo>("Dojodachi") == null){
                HttpContext.Session.SetObjectAsJson("Dojodachi", new MyDojodachiInfo());
            }

            ViewBag.Dojodachi = HttpContext.Session.GetObjectFromJson<MyDojodachiInfo>("Dojodachi");
            ViewBag.Message = "You have a new Dojodachi!";
            ViewBag.GameStatus = "running";
            ViewBag.Reaction = "";
            return View();
        }

        [HttpPost]
        [Route("completeActions")]
        public IActionResult completeActions(String action){

            MyDojodachiInfo AdjustInfo = HttpContext.Session.GetObjectFromJson<MyDojodachiInfo>("Dojodachi");
            Random randNum = new Random();
            ViewBag.GameStatus = "running";
            switch(action){
                case "feed":
                    if(AdjustInfo.Meals > 0){
                        AdjustInfo.Meals -= 1;
                        if(randNum.Next(0,4) > 0){
                            AdjustInfo.Fullness += randNum.Next(5,11);
                            ViewBag.Reaction = ":)";
                            ViewBag.Message = "Dojodachi enjoyed the food!";
                        }
                        else{
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "Dojodachi didn't like the food this time.";
                        }
                    }
                    else{
                        ViewBag.Reaction = ":(";
                        ViewBag.Message = "You do not have any meals for your Dojodachi!";
                    }
                    break;

                case "play":
                    if(AdjustInfo.Energy > 4){
                        AdjustInfo.Energy -= 5;
                        if(randNum.Next(0,4) > 0){
                            AdjustInfo.Happiness += randNum.Next(5,11);
                            ViewBag.Reaction = ":)";
                            ViewBag.Message = "Dojodachi had fun playing with you!";
                        }
                        else{
                            ViewBag.Reaction = ":(";
                            ViewBag.Message = "Dojodachi was not in the mood to play";
                        }
                    }
                    else{
                        ViewBag.Reaction = ":(";
                        ViewBag.Message = "There is not enough energy";
                    }
                    break;
                
                case "work":
                    if(AdjustInfo.Energy > 4){
                        AdjustInfo.Energy -= 5;
                        AdjustInfo.Meals += randNum.Next(1,4);
                        ViewBag.Reaction = ":)";
                        ViewBag.Message = "Job well done!";
                    }
                    else{
                        ViewBag.Reaction = ":(";
                        ViewBag.Message = "There is not enough energy";
                    }
                    break;

                case "sleep":
                    AdjustInfo.Energy += 15;
                    AdjustInfo.Fullness -= 5;
                    AdjustInfo.Happiness -= 5;
                    ViewBag.Reaction = ":)";
                    ViewBag.Message = "Dojodachi seems to have slept well";
                    break;
                
                default:
                    ViewBag.Reaction = "XXXXXX";
                    ViewBag.Message = "There seems to be a glitch...";
                    break;
            }

            if(AdjustInfo.Fullness < 1 || AdjustInfo.Happiness < 1){
                ViewBag.Reaction = "X(";
                ViewBag.Message = "OH NO! Dojodach has died";
                ViewBag.GameStatus = "over";
            }

            else if(AdjustInfo.Fullness > 99 && AdjustInfo.Happiness > 99){
                ViewBag.Reaction = ":D";
                ViewBag.Message = "Congratulations! You win!";
                ViewBag.GameStatus = "over";
            }

            HttpContext.Session.SetObjectAsJson("Dojodachi", AdjustInfo);
            ViewBag.Dojodachi = AdjustInfo;
            return View("Index");
        }

        [HttpGet]
        [Route("reset")]
        public IActionResult Reset(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }

    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}