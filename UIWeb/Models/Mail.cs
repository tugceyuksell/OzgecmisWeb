using System.Net;
using System.Net.Mail;

namespace UIWeb.Models
{
    public class Mail
    {
        public static void MailSender(string body)
        {
            var fromAddress = new MailAddress("rose59@ethereal.email");
            var toAddress = new MailAddress("rose59@ethereal.email");
            const string subject = "Özgemiş Sitesi Mail";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.ethereal.email",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "sifre")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}
