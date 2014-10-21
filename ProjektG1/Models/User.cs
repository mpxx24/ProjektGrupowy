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

        [DisplayName("Nazwa Użytkownika")]
        [Required(ErrorMessage = "pole wymagane")]
        public string Username { get; set; }

        [DisplayName("Hasło")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "pole wymagane")]
        public string Password { get; set; }

        public virtual ICollection<Task> Tasks { get; set; } 

        [DisplayName("Pamiętaj mnie")]
        public bool RememberMe { get; set; }


        public bool IsValid(string username, string password)
        {
            var context = new TaskContext();
            var slownik = new Dictionary<string, string>();

            foreach (var user in context.Users)
            {
                if (user.Username != null && user.Password != null)
                {
                    slownik.Add(user.Username, user.Password);
                    //if (user.Username.Equals(username) && user.Password.Equals(password))
                    //{
                    //    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}
                }
            }

            if (slownik.ContainsKey(username))
            {
                string value = slownik[username];
                if (value == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return Username;
        }
    }
}