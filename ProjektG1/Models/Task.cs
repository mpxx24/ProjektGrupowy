using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektG1.Models
{
    [Table("Task")]
    public class Task
    {
        public int ID { get; set; }
        public string Tytul { get; set; }
        public string OsobaOdpowiedzialna { get; set; }
        public DateTime DataDodania { get; set; }
        public DateTime Termin { get; set; }
        public string Komentarz { get; set; }
    }
}