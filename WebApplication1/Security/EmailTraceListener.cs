using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace WebApplication1.Security
{
    public class EmailTraceListener : TraceListener
    {
        public override void Write(string message)
        {
            WriteLine(message);
        }

        public override void WriteLine(string message)
        {
            MailMessage mail = new MailMessage();
            mail.Body = "<p style='font-size: 12px;color: red;'>"+message+"</p>";
            mail.IsBodyHtml = true;
            mail.Subject = "ERRO";
            mail.To.Add("marcelo.bernart@gmail.com");
            mail.From = new MailAddress("TRABALHOENTRA21@GMAIL.COM");

            SmtpClient servidor = new SmtpClient("smtp.gmail.com", 587);
            servidor.EnableSsl = true;
            servidor.UseDefaultCredentials = false;
            servidor.Credentials = new NetworkCredential("trabalhoentra21@gmail.com", "csharp>java");
            servidor.Send(mail);
        }
    }
}