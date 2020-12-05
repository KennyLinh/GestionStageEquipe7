using MailKit.Net.Smtp;
using Microsoft.Extensions.Logging;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionStageEquipe7.Services.Courriels
{
    public class EmailService : IEmailService
    {
        private readonly IEmailConfiguration _emailConfiguration;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IEmailConfiguration emailConfiguration, ILogger<EmailService> logger)
        {
            _emailConfiguration = emailConfiguration;
            _logger = logger;
        }

        public async Task<Exception> Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            var builder = new BodyBuilder();
            builder.HtmlBody = emailMessage.Content;

            message.To.AddRange(emailMessage.ToAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.From.AddRange(emailMessage.FromAddresses.Select(x => new MailboxAddress(x.Name, x.Address)));
            message.Subject = emailMessage.Subject;
            //We will say we are sending HTML. But there are options for plaintext etc. 
            //message.Body = new TextPart(TextFormat.Html)
            //{
            //    Text = emailMessage.Content
            //};

            //var attachments = new List<MimeEntity>
            //{
            //    // from stream with a content type defined
            //    MimeEntity.Load(new ContentType("application", "pdf"), emailMessage.PieceJointe)
            //};

            //builder.Attachments.Add(emailMessage.NomPieceJointe, emailMessage.PieceJointe, new ContentType("application", "pdf"));


            message.Body = builder.ToMessageBody();

            //Be careful that the SmtpClient class is the one from Mailkit not the framework!
            using (var emailClient = new SmtpClient())
            {
                try
                {
                    //emailClient.CheckCertificateRevocation = false;
                    //The last parameter here is to use SSL (Which you should!)
                    await emailClient.ConnectAsync(_emailConfiguration.SmtpServer, _emailConfiguration.SmtpPort, false);
                    //Remove any OAuth functionality as we won't be using it. 
                    emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    await emailClient.AuthenticateAsync(_emailConfiguration.SmtpUsername, _emailConfiguration.SmtpPassword);
                    await emailClient.SendAsync(message);
                    await emailClient.DisconnectAsync(true);
                    emailClient.Dispose();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Erreur dans l'envoi d'un courriel {ex}");
                    return ex;
                }
                return null;
            }
        }
    }
}

