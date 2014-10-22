using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProjektG1.Models;

namespace ProjektG1.Controllers
{
    public class UserController : Controller
    {
        
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.IsValid(user.Username, user.Password))
                {
                    FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                    return RedirectToAction("Zadanie", "Task");
                }
                else
                {
                    ModelState.AddModelError("", "Niepoprawne dane");
                }
            }
            return View(user);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            var context = new TaskContext();
            var nowyUser = new User()
            {
                Username = user.Username,//Request["Username"],
                Password = user.Password//Request["Password"]
            };

            context.Users.Add(nowyUser);

            context.SaveChanges();

            return RedirectToAction("PoRejestracji");
        }

        public ActionResult PoRejestracji()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Zadanie", "Task");
        }
        
    }
}
