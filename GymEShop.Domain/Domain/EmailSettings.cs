using System;
using System.Collections.Generic;
using System.Text;

namespace GymEShop.Domain.Domain
{
    public class EmailSettings
    {
        public string SmtpServer { get; set; }

        public string SmtpUsername { get; set; }

        public string SmtpPassword { get; set; }

        public string SmtpServerPort { get; set; }

        public string EnableSS { get; set; }

        public string EmailDisplayName { get; set; }

        public string SenderName { get; set; }
        public bool EnableSsl { get; set; }

        public EmailSettings() { }

        public EmailSettings(string SmtpServer, string SmtpUsername, string SmtpPassword, string SmtpServerPort)
        {
            this.SmtpServer = SmtpServer;
            this.SmtpUsername = SmtpUsername;
            this.SmtpPassword = SmtpPassword;
            this.SmtpServerPort = SmtpServerPort;
        }
    }
}
