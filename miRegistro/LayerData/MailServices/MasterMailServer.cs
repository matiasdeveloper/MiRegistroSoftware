using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;

namespace LayerData.MailServices
{
    public abstract class MasterMailServer
    {
        private SmtpClient smtpClient;
        protected string senderMail { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        protected void intialaizeSmtpClient() 
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public void sendMail(string subject, string body, string receptMail) 
        {
            var mailMessage = new MailMessage();
            try 
            {
                mailMessage.From = new MailAddress(senderMail);
                mailMessage.To.Add(receptMail);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.Priority = MailPriority.Normal;
                smtpClient.Send(mailMessage);
            } catch(Exception ex) 
            {
                Debug.WriteLine(ex);
            }
            finally 
            {
                mailMessage.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
