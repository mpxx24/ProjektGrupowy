using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using ProjektG1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektG1.Controllers
{
    public class TaskController : Controller
    {

        public ActionResult Zadanie()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            var taskContext = new TaskContext();
            var listaTaskow = new List<Task>();
            var listaGrup = new List<TaskGroup>();

            var vUser = this.User.Identity.Name;

            foreach (var task in taskContext.Tasks)
            {
                if (task.OsobaOdpowiedzialna == vUser)
                {
                    if (task.Zakonczone == false)
                    {
                        listaTaskow.Add(task);
                    }
                }
            }

            foreach (var grupa in taskContext.TaskGroups)
            {
                if (grupa.User.Username == vUser)
                {
                    listaGrup.Add(grupa);
                }
            }

            ViewBag.Zadanie = listaTaskow;
            ViewBag.Grupy = listaGrup;
            return View();

        }

        public ActionResult DodajTask()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            var taskContext = new TaskContext();
            var mojUser = Request["OsobaOdpowiedzialna"];
            var q = from u in taskContext.Users
                    where u.Username == mojUser
                    select u.UserId;
            var id = q.Single();

            var mojaGrupa = Convert.ToInt32(Request["TaskGroupId"]);

            var noweZadanie = new Task()
            {
                Tytul = Request["Tytul"],
                OsobaOdpowiedzialna = Request["OsobaOdpowiedzialna"],
                OsobaDodajacaZadanie = User.Identity.Name,
                User = taskContext.Users.Single(x => x.UserId == id),
                Komentarz = Request["Komentarz"],
                Zakonczone = false,
                DataDodania = DateTime.Now,
                Termin = Convert.ToDateTime(Request["Termin"]),
                TaskGroup = taskContext.TaskGroups.Single(x => x.TaskGroupId == mojaGrupa) 
            };

            if (noweZadanie.OsobaOdpowiedzialna != User.Identity.Name)
            {
                var mailC = new MailController();

                var doKogo = from u in taskContext.Users
                             where u.Username == noweZadanie.OsobaOdpowiedzialna
                             select u.UserId;
                var id2 = doKogo.Single();

                var thisUser = taskContext.Users.Single(x => x.UserId == id2);
                mailC.SendEmail(thisUser);

                if (thisUser.TaskGroups.Count.Equals(0))
                {
                    var grupa = new TaskGroup
                    {
                        User = thisUser,
                        GroupName = "Grupa"
                    };
                    thisUser.TaskGroups.Add(grupa);
                    noweZadanie.TaskGroup = grupa;
                }
                else
                {
                    var grupa = thisUser.TaskGroups.First();
                    noweZadanie.TaskGroup = grupa;
                }
            }
            
            taskContext.Tasks.Add(noweZadanie);
            taskContext.SaveChanges();
            return RedirectToAction("Zadanie", "Task");
        }

        public ActionResult EdytujTask(int id)
        {
            var context = new TaskContext();
            var doEdycji = context.Tasks.Single(x => x.ID == id);

            ViewBag.EditTask = doEdycji;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            var context = new TaskContext();
            var edytowanyTask = context.Tasks.Single(x => x.ID == id);
            edytowanyTask.ID = id;
            edytowanyTask.Tytul = Request["Tytul"];
            edytowanyTask.OsobaOdpowiedzialna = Request["OsobaOdpowiedzialna"];
            edytowanyTask.Komentarz = Request["Komentarz"];
            edytowanyTask.DataDodania = DateTime.Now;
            edytowanyTask.Termin = DateTime.Today;
            context.SaveChanges();

            return RedirectToAction("Zadanie", "Task");
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //int uId = Request["input"].Where()
            var context = new TaskContext();
            var doUsuniecia = context.Tasks.Single(z => z.ID == id);
            context.Tasks.Remove(doUsuniecia);
            context.SaveChanges();

            return RedirectToAction("Zadanie", "Task");
        }

        public ActionResult EndTask(int id)
        {
            var context = new TaskContext();
            var task = context.Tasks.Single(m => m.ID == id);
            task.Zakonczone = true;
            context.SaveChanges();
            return RedirectToAction("Zadanie", "Task");
        }
    }
}
