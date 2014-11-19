using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using ProjektG1.Models;

namespace ProjektG1.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            var hasher = new PHash();

            if (user.IsValid(user.Username, hasher.SHA1Hashuj(user.Password)))
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
                return RedirectToAction("Zadanie", "Task");
            }
            else
            {
                const string blad = "WrongLoginInfo";
                return RedirectToAction("Index", "Home", new {blad});
            }
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
            var hasher = new PHash();
            var nowyUser = new User()
            {
                Username = user.Username,
                Password = hasher.SHA1Hashuj(user.Password),
                MailAdress = user.MailAdress

            };

            if (context.Users.Any(x => x.Username == nowyUser.Username))
            {

            }
            else
            {
                context.Users.Add(nowyUser);
            }
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
            return RedirectToAction("Index", "Home");
        }

        public ActionResult DisplayAccData()
        {
            var context = new TaskContext();
            var displayUser = context.Users.Single(m => m.Username == User.Identity.Name);

            return View(displayUser);
        }

        public ActionResult EditAccData()
        {
            var context = new TaskContext();
            var editUser = context.Users.Single(m => m.Username == User.Identity.Name);

            return View(editUser);
        }


    }
}
