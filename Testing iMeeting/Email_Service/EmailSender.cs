using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Testing_iMeeting.Email_Service
{
    public class EmailSender
    {
         public string PopulateBody( string title, string Agenda, string Room,DateTime dateTime,int Duration, string Users)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("/Email_Service/EmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{Title}", title);
            body = body.Replace("{Agenda}", Agenda);
            body = body.Replace("{Room}", Room);
            body = body.Replace("{Users}", Users);
            body = body.Replace("{Duration}",  Duration.ToString());
            body = body.Replace("{dateTime}", dateTime.ToString());
            return body;
        }
        public void SendHtmlFormattedEmail(string subject, string body,string reciever)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress("autoislamabad@gmail.com");
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(reciever));
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["UserName"];
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mailMessage);
            }
        }
    }
}