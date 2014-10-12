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
        
        public ActionResult Zadanie(int id)
        {
            var taskContext = new TaskContext();
            var task = taskContext.Tasks.Single(tsk => tsk.ID == id);

            return View(task);
        }

    }
}
