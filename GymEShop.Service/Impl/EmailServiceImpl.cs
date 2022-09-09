using GymEShop.Domain.Domain;
using GymEShop.Service.Interface;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

/*namespace GymEShop.Service.Impl
{
    public class EmailServiceImpl : EmailService
    {
        private readonly EmailSettings settings;

        public EmailServiceImpl(EmailSettings settings)
        {
            this.settings = settings;
        }
        public async Task SendEmailAsync(List<EmailMessage> mails)
        {
            List<MimeMessage> message = new List<MimeMessage>();

            foreach(var mail in mails)
            {
                var emailMessage = new MimeMessage
                {
                    Sender = new MailboxAddress(settings.SenderName, settings.SmtpUsername),
                    Subject = mail.Subject
                };
                emailMessage.From.Add(new MailboxAddress(settings.SenderName, settings.SmtpUsername));
                emailMessage.Body = new TextPart(TextFormat.Plain) { Text = mail.Content };
                emailMessage.To.Add(new MailAddress(mail.MailTo));
                mails.Add(emailMessage);
            }

            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    var socketOption = settings.EnableSsl ? SecureSocketOptions.StartTls : SecureSocketOptions.Auto;
                    await smtp.ConnectAsync(settings.SmtpServer, settings.SmtpServerPort, socketOption);

                    if (!string.IsNullOrEmpty(settings.SmtpUsername))
                    {
                        await smtp.AuthenticateAsync(settings.SmtpUsername, settings.SmtpPassword);
                    }

                    foreach (var item in message)
                    {
                        await smtp.SendAsync(item);
                    }

                    await smtp.DisconnectAsync(true);
                }

            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }
    }
}*/
