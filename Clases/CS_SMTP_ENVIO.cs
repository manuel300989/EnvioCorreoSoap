using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace WebServiceEnviarCorreo.Clases
{
    public class CS_SMTP_ENVIO
    {

        public bool EnviarCorreo(MailMessage mailMessage)
        {
            try
            {
                MailMessage Envio = new MailMessage();
                Envio = mailMessage;

                SmtpClient smtp = new SmtpClient();

                smtp.Send(Envio);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}