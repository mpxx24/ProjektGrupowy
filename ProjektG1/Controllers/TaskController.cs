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

            foreach (var task in taskContext.Tasks)
            {
                listaTaskow.Add(task);
            }

            ViewBag.Zadanie = listaTaskow;

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

        public ActionResult EdytujTask(string str)
        {
            //
            // w bazie mogą zdarzyć się taski z tym samym tytułem! need fix
            //
            var context = new TaskContext();
            var doEdycji = context.Tasks.Single(x => x.Tytul == str);

            ViewBag.Tytul = doEdycji.Tytul;
            ViewBag.OsobaOdpowiedzialna = doEdycji.OsobaOdpowiedzialna;
            ViewBag.Komentarz = doEdycji.Komentarz;
            ViewBag.DataDonania = doEdycji.DataDodania;
            ViewBag.Termin = doEdycji.Termin;
            return View();
        }

        public ActionResult Edit(string str)
        {
            
            
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

    }
}
