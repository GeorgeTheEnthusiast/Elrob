namespace Elrob.NtService.Controllers
{
    using System;
    using System.Net;
    using System.Net.Mail;

    using NLog;

    public class EmailSenderController : IEmailSenderController
    {
        private readonly IConfigurationManager _configurationManager;
        private static ILogger _logger = LogManager.GetCurrentClassLogger();

        public EmailSenderController(IConfigurationManager configurationManager)
        {
            if (configurationManager == null)
            {
                throw new ArgumentNullException(nameof(configurationManager));
            }
            this._configurationManager = configurationManager;
        }

        public void SendEmail(string message, string subject)
        {
            _logger.Info("Sending email to {0} with subject {1}", this._configurationManager.DailyReportRecipient, subject);

            MailAddress mailAddressFrom = new MailAddress("elrob.terminal@gmail.com", "Elrob.Terminal");
            MailAddress mailAddressTo = new MailAddress(this._configurationManager.DailyReportRecipient);
            MailMessage mailMessage = new MailMessage(mailAddressFrom, mailAddressTo);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("elrob.terminal", "Elrob@123");
            smtpClient.Send(mailMessage);

            _logger.Info("Email has been sent.");
        }
    }
}