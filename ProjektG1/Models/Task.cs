using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjektG1.Models
{
    [Table("Task")]
    public class Task
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Nazwa zadania")]
        public string Tytul { get; set; }

        [DisplayName("Dodane przez")]
        public string OsobaDodajacaZadanie { get; set; }

        [DisplayName("Osoba odpowiedzialna za zadanie")]
        public string OsobaOdpowiedzialna { get; set; }

        [DisplayName("Data dodania zadania")]
        public DateTime DataDodania { get; set; }

        [DisplayName("Termin")]
        public DateTime Termin { get; set; }

        [DisplayName("Komentarz do zadania / opis zadania")]
        public string Komentarz { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}