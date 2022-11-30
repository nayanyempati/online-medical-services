using System.Net.Mail;

namespace online_medical_services.Helpers
{
    public class MailHelper
    {
        private Messages _messages = new Messages();
        public string SendActivationEmail(string firstname, string email, string activationLink)
        {
            string activationEmailLink = "http://localhost:4200/account/activate/" + activationLink;
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Directory.GetCurrentDirectory() + "/Templates/AccountActivation.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{FIRST_NAME}}", firstname);
            body = body.Replace("{{ACTIVATION_LINK}}", activationEmailLink);

            var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            if (config != null)
            {
                using (var mail = new MailMessage())
                {
                    mail.From = new MailAddress(config["EmailConfiguration:Email"]);
                    mail.To.Add(email);
                    mail.IsBodyHtml = true;
                    mail.Body = body;
                    mail.Subject = "Account activation - Online Medical Services";
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Timeout = 100000;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Host = config["EmailConfiguration:SmtpServer"];
                    smtpClient.Port = Convert.ToInt32(config["EmailConfiguration:Port"]);
                    smtpClient.Credentials = new System.Net.NetworkCredential(config["EmailConfiguration:Email"].ToString(), config["EmailConfiguration:Password"].ToString());
                    smtpClient.EnableSsl = true;
                    try
                    {
                        Task t = Task.Run(async () =>
                        {
                            await smtpClient.SendMailAsync(mail);
                        });
                        t.Wait();
                        return _messages.ACTIVATION_MAIL_SENT;
                    }
                    catch (IOException e)
                    {
                        return e.Message;
                    }
                    catch (FormatException e)
                    {
                        return e.Message;
                    }
                    catch (TimeoutException e)
                    {
                        return e.Message;
                    }
                }
               
            }
            return _messages.MISSING_CONFIGURATION;
        }
    }
}
