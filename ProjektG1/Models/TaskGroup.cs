using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektG1.Models
{
    public class TaskGroup
    {
        public int TaskGroupId { get; set; }
        public string GroupName { get; set; }
        public virtual ICollection<Task> ListaTaskow { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}