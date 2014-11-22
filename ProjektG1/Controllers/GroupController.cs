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

        [HttpPost]
        public ActionResult DeleteGroup(int? groupId)
        {
            if (groupId != null)
            {
                var group = context.TaskGroups.Single(m => m.TaskGroupId == groupId);
                var tasksInDelGroup = context.Tasks.Where(m => m.TaskGroupId == groupId).ToList();
                foreach (var task in tasksInDelGroup)
                {
                    context.Tasks.Remove(task);

                }
                context.TaskGroups.Remove(group);
                context.SaveChanges();
                return RedirectToAction("Zadanie", "Task");
            }
            else
            {
                return RedirectToAction("Zadanie", "Task");
            }
        }

    }
}
