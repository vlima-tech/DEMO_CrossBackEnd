
using Microsoft.AspNetCore.Mvc;

namespace CrossBackEnd.UI.Web.REST.API.Controllers
{
    [Route("api")]
    [Route("api/Home")]
    [Produces("application/json")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Json("Welcome to Home!!");
        }
    }
}