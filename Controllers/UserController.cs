using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Book_library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_library.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Registration Action
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Registration POST action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind("UserID, FirstName, LastName, Email, DateOfBirth, Password, ConfirmPassword")] User user)
        {
            bool status = false;
            string message = "";

            //Model Validation
            if (ModelState.IsValid)
            {
                //Email is already exist
            }
            else
            {
                message = "Invalid Request";
            }

            

            //Generate Activation Code

            //Password Hashing

            //Save data to Database

            //Send Email to User

            return View(user);
        }

        //Verify Email


        //Verify Email LINK


        //Login


        //Login POST


        //Logout

        [NonAction]
        public bool IsEmailExist(string email)
        {

        }
    }
}