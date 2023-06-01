using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Arambha.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Events()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Blogs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendMail(string name, string phonenumber,string emailid, string message)
        {
            var Mailbody = "Please find below Inquiry </br></br>" +Environment.NewLine+
                "<table style='border: 1px solid black;width:100%'>" +
                "<tr>" +
                "<th style='border: 1px solid black;'>Name</th>" +
                "<th style='border: 1px solid black;'>Phone Number</th>" +
                "<th style='border: 1px solid black;'>Email ID</th>" +
                "<th style='border: 1px solid black;'>Message</th>" +
                "</tr>" +
                "<tr>" +
                "<td style='border: 1px solid black;'>" + name + "</td>" +
                "<td style='border: 1px solid black;'>" + phonenumber + "</td>" +
                "<td style='border: 1px solid black;'>" + emailid + "</td>" +
                "<td style='border: 1px solid black;'>" + message + "</td>" +
                "</tr>" +
                "</table> ";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("mayuresh.vedak619@gmail.com");
            mail.To.Add("mayureshvedak@yahoo.com");
            mail.Subject = "Arambha new inquiry from "+name;
            mail.Body = Mailbody;
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("mayuresh.vedak619@gmail.com", "wkiduzaiosupsnwr");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
            return Json("Successfully Sent");
        }

    }
}