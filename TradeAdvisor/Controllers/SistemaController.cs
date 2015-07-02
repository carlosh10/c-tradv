using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace TradeAdvisor.Controllers
{
    public class SistemaController
    {
        public static void EnviaNotificacao(string mensagem)
        {
            try
            {
                MailAddress to = new MailAddress("notificacao@prinho.com.br");

                MailAddress from = new MailAddress("notificacao@prinho.com.br");
                MailMessage mail = new MailMessage(from, to);
                mail.Subject = "Notificação do site Trade Advisor";
                mail.Body = mensagem;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;

                smtp.Credentials = new NetworkCredential(
                    "anderson.anschau@pinho.com.br", "A#015724172348");
                smtp.EnableSsl = true;
                smtp.Send(mail);

            }
            catch (Exception ex)
            {
            }
        }
    }
}