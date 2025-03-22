using Core.Utilities.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CoreNT.Utilities
{
    public class SendMail
    {
        public static IResult Send(string email,string htmlString)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("techinsotfware@gmail.com", "Techin Software");
                message.To.Add(new MailAddress(email));
                message.Subject = "Bilgilendirme";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("techinsotfware@gmail.com", "157248Nt");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                return new SuccessResult("Mail gönderildi.");
            }
            catch (Exception err)
            {
                return new ErrorResult("Hata: " + err.Message);
            }
        }
    }
}
