using Microsoft.AspNetCore.Mvc;

namespace CopaDeEquipes.Api.Controllers
{
    public class CopaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}