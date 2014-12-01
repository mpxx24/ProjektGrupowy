using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ProjektG1.Models;

namespace ProjektG1.Controllers
{
    public class FileController : Controller
    {
       [HttpGet]
        public FileResult CreateFile()
        {
            var context = new TaskContext();
            var user = context.Users.Single(x => x.Username == User.Identity.Name);
            var dataString = "";
            var taskList = new List<Task>();
            dataString += "Group; Title; Added; Deadline; Comment\n";
            foreach (var task in user.Tasks)
            {
                dataString += task.TaskGroup.GroupName + ";" + task.Tytul + "; " + task.DataDodania
                    + " ; " + task.Termin + " ;" + task.Komentarz +"\n";
            }

            var byteArray = Encoding.ASCII.GetBytes(dataString);
            var stream = new MemoryStream(byteArray);
            return File(stream, "text/csv", "plikTestowy.csv");
        }

    }
}
