using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CallingCard.Controllers
{
    public class InfoController : Controller{

        [HttpGet]
        [Route("/{First_Name}/{Last_Name}/{Age}/{FaveColor}")]
        public JsonResult InfoCard(string First_Name, string Last_Name, int Age, string FaveColor)
        {
            return Json(new {FirstName = First_Name, LastName = Last_Name, Age = Age, FavoriteColor = FaveColor});
        }
    }
}