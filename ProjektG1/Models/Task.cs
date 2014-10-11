using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektG1.Models
{
    public class Task
    {
        public string Tytul { get; set; }
        public string OsobaOdpowiedzialna { get; set; }
        public DateTime DataDodania { get; set; }
        public DateTime Termin { get; set; }
        public string Komentarz { get; set; }
    }
}