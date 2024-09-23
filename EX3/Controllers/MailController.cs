using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using System.Dynamic;
using EX3.Models;

namespace EX3.Controllers
{
    public class MailController : Controller
    {
        // GET: Mail
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Send(MailInfo model)
        {
            // Cấu hình thông tin gmail
            var mail = new SmtpClient("smtp.gmail.com", 25)
            {
                Credentials = new NetworkCredential("22280201e0020@student.tdmu.edu.vn", "lfxi agiv jdmr rgkx"),
                EnableSsl = true

            };

            // Tạo email
            var message = new MailMessage();
            message.From = new MailAddress(model.From);
            message.ReplyToList.Add(model.From);
            message.To.Add(new MailAddress(model.To));
            message.Subject = model.Subject;
            message.Body = model.Body;

            // Gửi mail
            mail.Send(message);
            return View("Index");
        }
    }
}