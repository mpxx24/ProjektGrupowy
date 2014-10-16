using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektG1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektG1.Controllers
{
    public class TaskController : Controller
    {
        
        public ViewResult Zadanie()
        {
            var taskContext = new TaskContext();
            var ListaTaskow = new List<Task>();
            //Task task = taskContext.Tasks.Single(tk => tk.Tytul =="Zadanie");
            //var task = taskContext.Tasks.Single(tk => tk.ID == taskId);

            foreach (var task in taskContext.Tasks)
            {
                ListaTaskow.Add(task);
            }

            ViewBag.Zadanie = ListaTaskow;

            return View();
        }

    }
}
