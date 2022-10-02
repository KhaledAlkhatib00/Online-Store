using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TUITY_STORE.Models;
using System.Net;
using System.Net.Mail;



namespace TUITY_STORE.Controllers
{
    public class GmailController : Controller
    {
        public IActionResult SendMail()
        {
            return View();
        }


        [HttpPost]
        public IActionResult SendMail(TUITY_STORE.Models.Gmail model)
        {
            MailMessage mm = new MailMessage("Khaledalkhatib11@outlook.com", model.To);
            
            mm.Subject = model.Subject;
            mm.Body = model.Body;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.outlook.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;


            NetworkCredential nc = new NetworkCredential("Khaledalkhatib11@outlook.com", "Khaled@Noor@189@134");
            smtp.Credentials = nc;
            smtp.Send(mm);
            ViewBag.Message = "Mail Has Been Sent Succsesful";


            return View();
        }


        
    }
}
