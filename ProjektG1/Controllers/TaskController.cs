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
            //Task task = taskContext.Tasks.Single(tk => tk.Tytul =="Zadanie");
            //var task = taskContext.Tasks.Single(tk => tk.ID == taskId);
            ViewBag.Zadanie = new List<Task>()
            {
                new Task()
                {
                    ID = 1,
                    Tytul = "Zadanie",
                    DataDodania = DateTime.Now,
                    OsobaOdpowiedzialna = "mpiatkowski",
                    Komentarz = "test mvc",
                    Termin = DateTime.Today
                }
            };

            return View();
        }

    }
}
