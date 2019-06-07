using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReglasdeNegocio
{
    public class Correos
    {
        /*
            * Cliente SMTP
            * Gmail:  smtp.gmail.com  puerto:587
            * Hotmail: smtp.liva.com  puerto:25
        */
        public static bool Enviar(string Smtp, int Puerto, string Mail, string Password, bool SSL, MailMessage Mensaje)
        {
            try
            {
                SmtpClient server = new SmtpClient(Smtp, Puerto);
                server.Credentials = new System.Net.NetworkCredential(Mail, Password);
                server.Timeout = 10000000;
                server.EnableSsl = SSL;
                server.Send(Mensaje);
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                return false;
            }
        }
    }
}
