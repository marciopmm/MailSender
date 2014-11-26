using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailSender
{
    class Program
    {
        static void Main(string[] args)
        {
            string fromAddress = "marciopmm@gmail.com";
            string toAddress = "marcio@logicaldocs.com.br";
            string password = "";

            SmtpClient server = new SmtpClient("smtp.google.com", 587);
            server.DeliveryMethod = SmtpDeliveryMethod.Network;
            server.EnableSsl = true;
            server.UseDefaultCredentials = false;
            server.Credentials = new NetworkCredential(fromAddress, password);

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = "Teste",
                Body = "Teste de envio de email",
                IsBodyHtml = false
            })
            {
                server.Send(message);
            }
        }
    }
}
