using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Net.Mail;
using System.Net.Mail;
using System.IO;

namespace WebServiceEnviarCorreo
{
    /// <summary>
    /// Descripción breve de Service1
    /// </summary>
    [WebService(Namespace = "http://enviocorreo.apphb.com/servicecorreo.asmx")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ServiceCorreo : System.Web.Services.WebService
    {
        Clases.CS_SMTP_ENVIO Send_Email = new Clases.CS_SMTP_ENVIO();

        [WebMethod(Description = "Envio de Correo de confirmacion de nueva solicitud")]
        public bool SendEmailConfirmacionSolicitud(string From, string To, string Asunto, string Body, string Credential)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(From);
                    mailMessage.Subject = Asunto;
                    mailMessage.Body = Body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(To));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(mailMessage);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        [WebMethod(Description = "Envio de Correo de confirmacion de nueva solicitud Con Archivo Adjunto")]
        public bool SendEmailConfirmacionSolicitudAdjunto(string From, string To, string Asunto, string Body,byte[] PDF, string Credential)
        {
            try
            {
                MemoryStream memoryStream = new MemoryStream(PDF);
                using (MailMessage mailMessage = new MailMessage())
                {
                    Attachment attach = new Attachment(memoryStream, "Contrato.pdf", "application/pdf");
                    mailMessage.Attachments.Add(attach);
                    mailMessage.From = new MailAddress(From);
                    mailMessage.Subject = Asunto;
                    mailMessage.Body = Body;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(new MailAddress(To));
                    SmtpClient smtp = new SmtpClient();
                    smtp.Send(mailMessage);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}