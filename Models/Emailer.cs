using System;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.ComponentModel;


namespace DocShare.Models
{
    public class Emailer
    {

        public async Task SendEmail(Message message, string toEmail)
        {
            SmtpClient Client = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential()
                {
                    UserName = "contactcontactdental@gmail.com",
                    Password = "jnzrndnogfstyora"
                },
            };

            MailAddress FromEmail = new MailAddress("contactcontactdental@gmail.com", "Contact Dental");
            MailAddress ToEmail = new MailAddress(toEmail);

            MailMessage NewMessage = new MailMessage()
            {
                From = FromEmail,
                Subject = message.Subject,
                Body = message.MessageContent
            };

            NewMessage.To.Add(ToEmail);
            SendCompletedEventHandler Client_SendCompleted = null;
            Client.SendCompleted += Client_SendCompleted;
            await Client.SendMailAsync(NewMessage);
        }

        private void Client_SendCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            else
            {
                Console.WriteLine("Sent Successfully!");
            }
        }
    }
}
