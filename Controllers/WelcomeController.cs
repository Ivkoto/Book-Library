using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
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
        public string Welcome(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}