using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjektG1.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [DisplayName("Nazwa Uzytkownika")]
        public string Username { get; set; }
        [DisplayName("Hasło")]
        public string Password { get; set; }
        public List<Task> Task { get; set; } 

    }
}