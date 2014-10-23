using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ProjektG1.Models;

namespace ProjektG1.Controllers
{
    public class MailController : Controller
    {
        //
        // GET: /Mail/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void SendEmail(User doKogo)
        {
            //var tUser = User.Identity.Name;
            var eMail = new Mail()
            {
                From = "projektgrupowy1@gmail.com",
                To = doKogo.MailAdress,
                Subject = "Dodano Ci zadanie!",
                Body = "Cześć! \nwygląda na to, że ktoś dodał Ci zadanie! " +
                       "\nZaloguj się na naszej stronie, żeby dowiedzieć się więcej :)" +
                       "\n\n(ta wiadomość została wygenerowana automatycznie, prosimy na nią nie odpowiadać)"
            };

            var nowyMail = new MailMessage();
            nowyMail.To.Add(eMail.To);
            nowyMail.From = new MailAddress(eMail.From);
            nowyMail.Subject = eMail.Subject;
            nowyMail.Body = eMail.Body;

            var client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("projektgrupowy1", "qwerty24");
            client.EnableSsl = true;
            client.Send(nowyMail);
        }
    }
}
