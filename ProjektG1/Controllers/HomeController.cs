using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektG1.Models;

namespace ProjektG1.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DodajUzytkownika()
        {
            var context = new TaskContext();
            var nowyUser = new User()
            {
                Username = Request["Username"],
                Password = Request["Password"]
            };
            context.Users.Add(nowyUser);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
