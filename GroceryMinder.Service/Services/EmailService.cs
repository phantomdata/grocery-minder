using GroceryMinder.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GroceryMinder.Service.Services
{
    public interface IEmailService
    {
        void Configure(string smtpServer, string smtpPort, string smtpUsername, string smtpPassword);
        void SendShoppingList(string to, GroceryList groceryList, string shoppingCompleteUrl);
    }

    public class EmailService : IEmailService
    {
        private bool isConfigured;
        private string smtpServer;
        private int smtpPort;
        private string smtpUsername;
        private string smtpPassword;

        public void Configure(string smtpServer, string smtpPort, string smtpUsername, string smtpPassword)
        {
            this.smtpServer = smtpServer;
            if (string.IsNullOrEmpty(this.smtpServer)) throw new ArgumentException("No smtp server specified");

            var success = Int32.TryParse(smtpPort, out this.smtpPort);
            if (!success) throw new ArgumentException(string.Format("\"{0}\" was not a proper integer for smtp port configuration."));

            this.smtpUsername = smtpUsername;
            if (string.IsNullOrEmpty(this.smtpUsername)) throw new ArgumentException("No smtp username specified");

            this.smtpPassword = smtpPassword;
            if (string.IsNullOrEmpty(this.smtpPassword)) throw new ArgumentException("No smtp password specified");

            isConfigured = true;
        }

        public void SendShoppingList(string to, GroceryList groceryList, string shoppingCompleteUrl)
        {
            var client = getSmtpClient();
            var mail = getBaseMailMessage(to);

            mail.Subject = string.Format("GroceryMinder - Shopping List for {0}", DateTime.Now.ToShortDateString());
            mail.Body = groceryList.ToText();
            mail.Body += string.Format("\nGo to {0} in order to mark your shopping done for the week!", shoppingCompleteUrl);

            client.Send(mail);
        }

        private MailMessage getBaseMailMessage(string to)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("noreply@phantomdata.com", "GroceryMinder");
            mail.To.Add(new MailAddress(to));

            return mail;
        }

        private SmtpClient getSmtpClient()
        {
            if (!isConfigured)
            {
                throw new Exception("The base mailer did not have Configure called prior to usage.");
            }

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);

            smtpClient.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;

            return smtpClient;
        }
    }
}
