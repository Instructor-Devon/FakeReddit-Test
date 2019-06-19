using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFFunzies.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace EFFunzies.Controllers
{
    public abstract class UserAccessController : Controller
    {
        protected int? SessionUser
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
    }
    public class HomeController : UserAccessController
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
        
            return View();
        }
        [HttpPost("login")]
        public IActionResult Login(LoginUser user)
        {
            // 1) make sure an email exists in db with email provided
            User userAttempt = dbContext.Users.FirstOrDefault(u => u.Email == user.LogEmail);
            if(userAttempt == null)
            {
                ModelState.AddModelError("LogEmal", "Invalid Email/Password");
                return View("Index");
            }
            else
            {
            // 1a) if so, check password for that user against provided password
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                PasswordVerificationResult result = hasher.VerifyHashedPassword(user, userAttempt.Password, user.LogPassword);
                if(result == PasswordVerificationResult.Failed)
                {
                    // we are failed
                    ModelState.AddModelError("LogEmail", "Invalid Email/Password");
                    return View("Index");
                }
                // 2) store user'd id in session
                SessionUser = userAttempt.UserId;
                // 3) redirect somewehere cool!
                return RedirectToAction("Index", "Dashboard");

            }

            // return RedirectToAction("Index");
        }
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(ModelState.IsValid)
            {
                // is email taken?
                if(dbContext.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email is already in use!");
                    return View("Index");
                }
                // hash password
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                string hash = hasher.HashPassword(user, user.Password);

                // attach the hashed pw to the user object
                user.Password = hash;
                
                dbContext.Users.Add(user);
                dbContext.SaveChanges();

                // store user's id in session...
                // we can use user.UserId now to store in session
                SessionUser = user.UserId;

                // OR make new query for User with Email (for quarenteed uniques?? do we need?)

                return RedirectToAction("Index", "Dashboard");
            }
            return RedirectToAction("Index");
        }

        [HttpGet("{userId}")]
        public IActionResult Show(int userId)
        {
            var user = dbContext.Users
                .Include(u => u.MessagesCreated)
                    .ThenInclude(m => m.VotesRecieved)
                    .ThenInclude(v => v.Voter)
                .FirstOrDefault(u => u.UserId == userId);

            return View(user);
        }
    }
}
