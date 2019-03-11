using EnterpriseSolution.Core.Entities;
using EnterpriseSolution.Core.Repositories;
using EnterpriseSolution.Core.Services;
using EnterpriseSolution.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseSolution.Infrastructure.Services
{
    public class NotificationService : INotificationService
    {
        IRepository<EmailConfiguration> emailConfigurationRepository;
        IRepository<ErrorLog> errorLogRepository;
        IRepository<Users> usersRepository;

        public NotificationService(IRepository<EmailConfiguration> emailConfigurationRepository, 
            IRepository<ErrorLog> errorLogRepository, IRepository<Users> usersRepository)
        {
            this.emailConfigurationRepository = emailConfigurationRepository;
            this.errorLogRepository =  errorLogRepository;
            this.usersRepository = usersRepository;
        }

        public void SendNotificationEmail(string toAddress, string emailNotificationFor, string dearConcerned)
        {
            try
            {
                var result = emailConfigurationRepository.GetAll().FirstOrDefault();
                if (result != null)
                {

                    MailMessage message = new MailMessage(result.FromAddress, toAddress, this.EmailSubject(emailNotificationFor), this.EmailBody(emailNotificationFor, dearConcerned));
                    message.IsBodyHtml = true;
                    SmtpClient client = new SmtpClient(result.SmtpServer, result.SmtpPort);

                    client.EnableSsl = false;
                    client.Credentials = new NetworkCredential(result.NetworkUserEmail, result.NetworkUserPass);
                    client.Send(message);
                }
            }
            catch (Exception ex)
            {
                var log = new ErrorLog()
                {
                    Operations = emailNotificationFor,
                    ErrorMessage = ex.GetBaseException().Message,
                    OccuredOn = DateTime.Now
                };
                
                errorLogRepository.Insert(log);
            }
        }

        protected string EmailSubject(string emailNotificationFor)
        {
            switch (emailNotificationFor)
            {
                case "New User":
                    emailNotificationFor = "Your account has been created";
                    break;
                case "Password Reset":
                    emailNotificationFor = "Password Reset";
                    break;
                case "Forgot Password":
                    emailNotificationFor = "New Password Request";
                    break;
                default:
                    break;
            }
            return emailNotificationFor;
        }

        protected string EmailBody(string emailNotificationFor, string dearConcerned)
        {
            StringBuilder sb = new StringBuilder();
            switch (emailNotificationFor)
            {
                case "New User":
                    {
                        long userId = Convert.ToInt64(dearConcerned);
                        var user = usersRepository.Get(userId);
                        var newPassword = Constants.GeneratePassword(8, 3); // Default Password Length 8
                        user.Password = Constants.GetSecurePassword(newPassword); // One Way Hash Using SHA256 Algorithm
                        usersRepository.Update(user);

                        sb.Append(String.Format("Dear {0},", user.FirstName + " " + user.LastName));
                        sb.Append("<br/>");
                        sb.Append("<p> Here is your account details.</p>");
                        sb.Append("<p> Your User Name: " + user.Email + "</p>");
                        sb.Append("<p> Your PassWord: " + newPassword + "</p>");
                        sb.Append("<p> Please confirm to <a href='http://localhost:62329/'>login</a></p>");
                        sb.Append("<br>");
                        break;
                    }
                case "Forgot Password":
                    {
                        sb.Append(String.Format("Dear {0},", dearConcerned));
                        sb.Append("<br/>");
                        sb.Append("<p> Please use the following link to reset your password.</p>");
                        sb.Append("<br>");
                        sb.Append("<p><a href='http://www.arcadiacare.co.uk/admin'>click here to reset your password</a></p>");
                        sb.Append("<br>");
                        
                        break;
                    }
                default:
                    break;
            }

            sb.Append(" Kind Regards");
            sb.Append("<br/>");
            sb.Append("<b> Enterprise Solution Team</b>");
            //sb.Append("<b> 72, Yardley Road, Acocks Green, </b>");
            //sb.Append("<br/>");
            //sb.Append("<b> Birmingham B27 6LG, UK</b>");
            //sb.Append("<br/>");
            //sb.Append("<b> Phone:+ 44 (0) 121 706 9546</b>");

            return sb.ToString();
        }
    }
}
