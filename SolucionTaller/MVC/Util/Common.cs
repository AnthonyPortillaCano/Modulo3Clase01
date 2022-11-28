using System.Text;
using System.Security.Cryptography;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace MVC.Util
{
    public class Common
    {
        public string GetSHA256(string input)
        {
            SHA256  sHA256= SHA256.Create();
            ASCIIEncoding encoding= new();
            StringBuilder sb = new();
            byte[] stream = sHA256.ComputeHash(encoding.GetBytes(input));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }
        public Task SendEmailAsync(string email,string urlClave)
        {
            var emailFinal = new MimeMessage();
            emailFinal.From.Add(MailboxAddress.Parse("CursoGalaxyNet6@outlook.com"));
            emailFinal.To.Add(MailboxAddress.Parse(email));
            emailFinal.Subject = "Recuperacion de contraseña";
            emailFinal.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = "<p>Correo para recuperacion de contraseña</p><br>" + "<a href='" + urlClave + "'>Click para recuperar</a>" };

            //Enviar email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("CursoGalaxyNet6@outlook.com", "12345nek22");
            smtp.Send(emailFinal);
            smtp.Disconnect(true);
            return Task.CompletedTask;
        }
    }
}
