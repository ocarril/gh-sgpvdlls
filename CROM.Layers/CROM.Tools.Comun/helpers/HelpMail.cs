using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using CROM.Tools.Comun.settings;
using System.Net.Mime;
using Newtonsoft.Json;

namespace CROM.Tools.Comun
{
   
    
    public class HelpMail
    {

        public static string CrearCuerpo(string pTitulo, List<HelpMailDatos> pMailDatos, string pNota, string pEmpresa, string pListado = "")
        {
            string body = ResourceIconos.Body.ToString();
            StringBuilder lsDatos = new StringBuilder();
            body = body.Replace("@titulo", pTitulo);
            body = body.Replace("@fecha", DateTime.Today.ToShortDateString());

            foreach (var item in pMailDatos)
            {
                if (item.titulo == "" || item.titulo == null)
                {
                    lsDatos.AppendLine("<tr><td colspan='2' >" + item.descripcion + "</td></tr>");

                }
                else
                {
                    lsDatos.AppendLine("<tr><td >" + item.titulo + "</td><td style='width:80%;'>" + item.descripcion + "</td></tr>");
                }
            }
            body = body.Replace("@datos", lsDatos.ToString());
            body = body.Replace("@nota", pNota);
            body = body.Replace("@empresa", pEmpresa);
            body = body.Replace("@anio", DateTime.Now.AddHours(GlobalSettings.GetDEFAULT_HorasFechaActualCloud()).Year.ToString());
            body = body.Replace("@versionapp", ConfigurationManager.AppSettings["webpages:Version"].ToString());

            pListado = string.IsNullOrWhiteSpace(pListado) ? string.Empty : pListado;

            body = body.Replace("@listado", pListado);

            return body;
        }

        /// <summary>
        ///Estos valores en el Config para su configuracion
        ///add key="CorreoDE" value="desarrollo@gmail.com" 
        ///add key="CredencialUser" value="desarrollo@gmail.com" 
        ///add key="CredencialPass" value="gmail**" 
        ///add key="Host" value="mail.gmail.com" 
        /// </summary>
        /// <param name="pSubject">Asunto</param>
        /// <param name="pBody">Cuerpo del mensaje</param>
        /// <param name="pEmail">Correo destino</param>
        public static void Enviar(string pSubject, string pBody, List<string> lstEmails, bool indEnvioOculto,
                                  List<string> lstAttachments, CuentaCorreoEnvio pCuentaCorreoEnvio)
        {
            bool strEMAIL_SSL = false; 
            string strEMAIL_Server = string.Empty;
            string strEMAIL_CredUsuario = string.Empty;
            string strEMAIL_CredClave = string.Empty;
            string strEMAIL_Subject= string.Empty;
            int strEMAIL_Puerto = 0;

            if (pCuentaCorreoEnvio == null)
            {
                strEMAIL_SSL = GlobalSettings.GetEMAIL_enabledSSL();
                strEMAIL_Server = GlobalSettings.GetEMAIL_Host();
                strEMAIL_CredUsuario = GlobalSettings.GetEMAIL_CredencialUser();
                strEMAIL_CredClave = GlobalSettings.GetEMAIL_CredencialPass();
                strEMAIL_Puerto = GlobalSettings.GetEMAIL_SmtpPort();
                strEMAIL_Subject = string.Format(GlobalSettings.GetEMAIL_Asunto(), " - ", pSubject);
            }
            else
            {
                strEMAIL_SSL = pCuentaCorreoEnvio.EnabledSSL;
                strEMAIL_Server = pCuentaCorreoEnvio.Host;
                strEMAIL_CredUsuario = pCuentaCorreoEnvio.CredencialUser;
                strEMAIL_CredClave = pCuentaCorreoEnvio.CredencialPass;
                strEMAIL_Puerto = pCuentaCorreoEnvio.SmtpPort;
                strEMAIL_Subject = string.Concat(pCuentaCorreoEnvio.EmailSubject, pSubject);
            }

            MailMessage correo = new MailMessage
            {
                From = new MailAddress(strEMAIL_CredUsuario, pSubject, Encoding.UTF8),
                Subject = strEMAIL_Subject,
                SubjectEncoding = System.Text.Encoding.UTF8,
                Body = pBody,
                IsBodyHtml = true,
                Priority = System.Net.Mail.MailPriority.High,
            };
            foreach (string strCorreo in lstEmails)
            {
                if (EsEmailValido(strCorreo))
                {
                    if (indEnvioOculto)
                        correo.Bcc.Add(strCorreo);
                    else
                        correo.To.Add(strCorreo);
                }
                else
                    throw new Exception(string.Format("Correo electrónico es inválido: {0}", strCorreo));
            }

            if (lstAttachments != null) {
                foreach(string cadaFile in lstAttachments)
                {
                    // Create  the file attachment for this email message.
                    Attachment data = new Attachment(cadaFile, MediaTypeNames.Application.Octet);
                    // Add time stamp information for the file.
                    ContentDisposition disposition = data.ContentDisposition;
                    disposition.CreationDate = System.IO.File.GetCreationTime(cadaFile);
                    disposition.ModificationDate = System.IO.File.GetLastWriteTime(cadaFile);
                    disposition.ReadDate = System.IO.File.GetLastAccessTime(cadaFile);
                    // Add the file attachment to this email message.
                    correo.Attachments.Add(data);
                }
                
             }

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient
                {
                    Credentials = new NetworkCredential(strEMAIL_CredUsuario, strEMAIL_CredClave),
                    Port = strEMAIL_Puerto,
                    Host = strEMAIL_Server,
                    EnableSsl = strEMAIL_SSL,
                    //DeliveryMethod = SmtpDeliveryMethod.Network,
                    //UseDefaultCredentials = false,
                };
            try
            {
                smtp.Send(correo);
            }
            catch (Exception)
            {
                throw;
            }
            correo = null;
        }

        public static bool EsEmailValido(String strEmail)
        {
            return Regex.IsMatch(strEmail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }
    }

    public class HelpMailDatos
    {
        public string titulo { get; set; }
        public string descripcion { get; set; }
    }

    /// <summary>
    /// Clase Para estructurar a los correos NO ENVIADOS
    /// </summary>
    public class CorreoNoEnviado
    {
        public string Body { get; set; }
        public List<string> Recipients { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
        public string Host { get; set; }
        public string CredUser { get; set; }
        public string CredPass { get; set; }

    }

    public class CuentaCorreoEnvio
    {
        public CuentaCorreoEnvio()
        {
            CredencialUser = string.Empty;
            CredencialPass = string.Empty;
            lstAttachments = new List<string>();
            pDetalleListaHTML = string.Empty;
            pTitulo = string.Empty;
            pUserLogin = string.Empty;
            Nota = string.Empty;
            Host = string.Empty;
            EmailSubject = string.Empty;
        }

        public string CredencialUser { get; set; }

        public string CredencialPass { get; set; }

        public string Host { get; set; }

        public int SmtpPort { get; set; }

        public bool EnabledSSL { get; set; }

        public string EmailSubject { get; set; }

        [JsonIgnore]
        public string Nota { get; set; }

        public string Aviso { get; set; }

        [JsonIgnore]
        public string pUserLogin { get; set; }

        [JsonIgnore]
        public string pTitulo { get; set; }

        [JsonIgnore]
        public string pDetalleListaHTML { get; set; }

        [JsonIgnore]
        public List<string> lstAttachments { get; set; }

        [JsonIgnore]
        public string pnomEmpresa { get; set; }

        [JsonIgnore]
        public int codEmpresa { get; set; }

        [JsonIgnore]
        public string ctaEmailAlertar { get; set; }
    }

}
