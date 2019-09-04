using Book_library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Book_library.Security;
using Microsoft.AspNetCore.Http;

namespace Book_library.Controllers
{
    public class UsersController : Controller
    {
        private readonly Book_libraryContext context;

        public UsersController(Book_libraryContext context)
        {
            this.context = context;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            return View(await context.User.ToListAsync());
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
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist!");
                    return View(user);
                }

                //Generate Activation Code
                user.ActivationCode = Guid.NewGuid();

                //Password Hashing
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);

                user.IsEmailVerified = false;

                //Save data to Database
                context.User.Add(user);
                context.SaveChanges();

                //Send Email to User
                SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
            }
            else
            {
                message = "Invalid Request";
            }            

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
            var curUser = context.User.Where(u => u.Email == email).FirstOrDefault();

            return curUser == null ? false : true;
        }

        [NonAction]
        public void SendVerificationLinkEmail(string email, string activationCode)
        {
            var verifyUrl = "User/VerifyAccount/" + activationCode;
            //TODO
        }





        //AUTO GENERATE CODE:

        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,FirstName,LastName,Email,DateOfBirth,Password,ConfirmPassword,IsEmailVerified,ActivationCode")] User user)
        {
            if (ModelState.IsValid)
            {
                context.Add(user);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,FirstName,LastName,Email,DateOfBirth,Password,ConfirmPassword,IsEmailVerified,ActivationCode")] User user)
        {
            if (id != user.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(user);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.UserID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await context.User
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await context.User.FindAsync(id);
            context.User.Remove(user);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return context.User.Any(e => e.UserID == id);
        }
    }
}
