using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Arambha.WebApp.Controllers
{
    public class HomeController : Controller
    {
        [Route("~/")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("Services")]
        public ActionResult Services()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("Clients")]
        public ActionResult Clients()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("Blogs")]
        public ActionResult Blogs()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Route("CertificatesPage")]
        public ActionResult CertificatesPage()
        {
            ViewBag.Message = "Your Certificates page.";

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
            SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["Mailsmtp"].ToString());

            mail.From = new MailAddress("customercare@ahs.net.in");
            mail.To.Add(ConfigurationManager.AppSettings["MailTo"].ToString());
            mail.Subject = "Arambha new inquiry from "+name;
            mail.Body = Mailbody;
            mail.IsBodyHtml = true;

            SmtpServer.Port = Convert.ToInt32(ConfigurationManager.AppSettings["MailPort"].ToString());
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("customercare@ahs.net.in", "hshmwwuektsxjice");
            SmtpServer.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["MailEnableSSL"]);
            try
            {
                SmtpServer.Send(mail);
                return Json("Inquiry sent successfully", JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

    }
}