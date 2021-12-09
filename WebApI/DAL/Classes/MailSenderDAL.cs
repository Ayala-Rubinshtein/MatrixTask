using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace DAL
{
    public class MailSenderDAL
    {

        public void SendEmail(string contactAddress, string subject, string body)
        {
            string FromMail = "ravcevel.system@gmail.com";
            //string FromMail = "finallproject1@gmail.com";
            string emailTo = contactAddress;
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(FromMail, "רבכבל אונליין");
            SmtpServer.UseDefaultCredentials = true;
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            mail.ReplyToList.Add("ravcevel@gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;

            SmtpServer.Credentials = new System.Net.NetworkCredential("ravcevel.system@gmail.com", "Sari-30020010");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("finallproject1@gmail.com", "finallProject11");
            SmtpServer.EnableSsl = true;
            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
            }
        }

        //קוד לשליחת מייל +צירוף קבצים
        //public static void SendMail(string subjecct, string body, string Address, string from = null, string PathToFile = null)
        //{
        //    // שם המייל- ההזדהות
        //    MailMessage msg = new MailMessage() { From = new MailAddress("xxxx@gmail.com", "המזון הקניה המשתלמת ביותר") };
        //    if (from != null)
        //    {
        //        //למי להחזיר את המייל(ממש לא חובה)
        //        msg.ReplyToList.Add(from);
        //    }
        //    //כתובת
        //    msg.To.Add(Address);
        //    //נושא
        //    msg.Subject = subjecct;
        //    //גוף התוכן
        //    msg.Body = body;
        //    //האם הצורה היא HTML כלומר DIV וכו או סתם טקסט
        //    msg.IsBodyHtml = true;

        //    //msg.Priority = MailPriority.High;
        //    //צירוף קובץ  למייל
        //    if (PathToFile != null)
        //    {
        //        try
        //        {
        //            Attachment attach;
        //            attach = new Attachment(PathToFile, "application/pdf");
        //            msg.Attachments.Add(attach);
        //        }
        //        catch (Exception e)
        //        {

        //            throw e;
        //        }

        //    }
        //    try
        //    {
        //        using (SmtpClient client = new SmtpClient())
        //        {
        //            client.EnableSsl = true;
        //            client.UseDefaultCredentials = false;
        //            client.Credentials = new NetworkCredential("xxxxxx@gmail.com", "xxxxxxx");
        //            client.Host = "smtp.gmail.com";
        //            client.Port = 587;
        //            client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //            client.Send(msg);
        //        }
        //        if (PathToFile != null)
        //        {
        //            msg.Attachments.Dispose();

        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;

        //    }
        //}
    }
}
