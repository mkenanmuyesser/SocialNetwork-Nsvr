using NeSever.Common.Models.Program;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace NeSever.Common.Utils.Email
{
    public static class EmailHelper
    {
        public static async Task<bool> EpostaGonder(EpostaVM model)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient(model.GonderilecekEpostaHost, model.GonderilecekEpostaPort);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(model.GonderilecekEpostaKullaniciAdi, model.GonderilecekEpostaSifre);
                smtpClient.EnableSsl = model.GonderilecekEpostaSsl;

                MailMessage mail = new MailMessage();
                mail.IsBodyHtml = true;
                mail.Subject = "Kurumsal İletişim E-posta";
                mail.Body = model.GonderilecekEpostaIcerik;
                mail.From = new MailAddress(model.GonderilecekEpostaKullaniciAdi, model.GonderilecekEpostaTanim);
                mail.To.Add(new MailAddress(string.IsNullOrEmpty(model.GonderilecekEposta) ? model.GonderilecekEpostaKullaniciAdi : model.GonderilecekEposta));

                await smtpClient.SendMailAsync(mail);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
