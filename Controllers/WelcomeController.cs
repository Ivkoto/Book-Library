using Microsoft.AspNetCore.Mvc;

namespace Book_library.Controllers
{
    public class WelcomeController : Controller
    {
        //GET: /Hello/Index
        public IActionResult Index()
        {
            return View();
        }

        //GET: /Hello/Welcome
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            ViewBag.NumTimes = numTimes;

            return View();
        }
    }
}