using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektG1.Models;

namespace ProjektG1.Controllers
{
    public class GroupController : Controller
    {
        private readonly TaskContext context = new TaskContext();
        public ActionResult AddGroup()
        {
            var user = context.Users.Single(m => m.Username == User.Identity.Name);
            var group = new TaskGroup()
            {
                GroupName = "Grupa",
                User = user,
                UserId = user.UserId
            };
            context.TaskGroups.Add(group);
            context.SaveChanges();
            return RedirectToAction("Zadanie", "Task");
        }

    }
}
