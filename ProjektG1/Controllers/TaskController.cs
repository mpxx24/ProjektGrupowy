using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjektG1.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektG1.Controllers
{
    public class TaskController : Controller
    {
        
        public ActionResult Zadanie()
        {
            var taskContext = new TaskContext();
            var listaTaskow = new List<Task>();
            //Task task = taskContext.Tasks.Single(tk => tk.Tytul =="Zadanie");
            //var task = taskContext.Tasks.Single(tk => tk.ID == taskId);

            foreach (var task in taskContext.Tasks)
            {
                listaTaskow.Add(task);
            }

            ViewBag.Zadanie = listaTaskow;

            return View();
        }

        ////public ActionResult DodajTask(string tytul, string osobaOdp, DateTime termin, string komentarz)
        ////{
        ////    var context = new TaskContext();
        ////    var nowyTask = new Task()
        ////    {
        ////        Tytul = tytul,
        ////        DataDodania = DateTime.Now,
        ////        OsobaOdpowiedzialna = osobaOdp,
        ////        Termin = termin,
        ////        Komentarz = komentarz
        ////    };
        ////    context.Tasks.Add(nowyTask);
        ////    context.SaveChanges();
        ////}
        
        
        public ActionResult DodajTask()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create()
        {
            var taskContext = new TaskContext();
            var noweZadanie = new Task()
            {
                Tytul = Request["Tytul"],
                OsobaOdpowiedzialna = Request["OsobaOdpowiedzialna"],
                Komentarz = Request["Komentarz"],
                DataDodania = DateTime.Now,
                Termin = DateTime.Today
            };
            taskContext.Tasks.Add(noweZadanie);
            taskContext.SaveChanges();
            return RedirectToAction("Zadanie", "Task");
        }

        public ActionResult EdytujTask(Task zadanie)
        {
            //??
            ViewData["ZadDoEdycji"] = new Task();
            
            return View();
        }

        public ActionResult Edit()
        {


            return RedirectToAction("Zadanie", "Task");
        }

    }
}
