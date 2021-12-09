using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using DAL;
using DAL.Classes;

namespace BLL
{
    public class MailSender
    {
        public void SendEmail(string contactAddress, string subject, string body)
        {
            try
            {
                new MailSenderDAL().SendEmail(contactAddress, subject, body);
                //string FromMail = "ravcevel.system@gmail.com";
                ////string FromMail = "finallproject1@gmail.com";
                //string emailTo = contactAddress;
                //MailMessage mail = new MailMessage();
                //mail.IsBodyHtml = true;
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress(FromMail, "רבכבל אונליין");
                //SmtpServer.UseDefaultCredentials = true;
                //mail.To.Add(emailTo);
                //mail.Subject = subject;
                //mail.Body = body;
                //mail.ReplyToList.Add("ravcevel@gmail.com");
                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("ravcevel.system@gmail.com", "Sari-30020010");
                ////SmtpServer.Credentials = new System.Net.NetworkCredential("finallproject1@gmail.com", "finallProject11");
                //SmtpServer.EnableSsl = true;
                //try
                //{
                //    SmtpServer.Send(mail);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }
        }
    }
}
