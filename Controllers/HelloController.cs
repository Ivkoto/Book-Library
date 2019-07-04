using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Book_library.Controllers
{
    public class HelloController : Controller
    {
        //GET: /Hello/Index
        public string Index()
        {
            return "This is my default action...";
        }

        //GET: /Hello/Welcome
        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}