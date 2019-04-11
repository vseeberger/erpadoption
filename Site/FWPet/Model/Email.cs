using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace FWPet.Model
{
    public class Email
    {
        public SmtpClient Client = new SmtpClient();
        public MailMessage Message = new MailMessage();

        public Email()
        {
            Client.Host = ConfigurationManager.AppSettings["MHost"].ToString();
            Client.Port = int.Parse(ConfigurationManager.AppSettings["MPort"].ToString());
            Client.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["MSSL"].ToString());
            Client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["MUser"].ToString(), ConfigurationManager.AppSettings["MPass"].ToString());
            Message.IsBodyHtml = true;
            Message.From = new MailAddress(ConfigurationManager.AppSettings["MUser"].ToString(), ConfigurationManager.AppSettings["MName"].ToString());
        }
    }
}
