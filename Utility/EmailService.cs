using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace OnlineFoodDelivery.Utility
{
    public interface IEmailService
    {
        Task SendResetPasswordEmail(string email, string resetToken);
    }

    public class EmailService : IEmailService
    {
        public async Task SendResetPasswordEmail(string email, string resetToken)
        {
            try
            {
                
                var resetLink = $"https://localhost:7212/api/User/resetPassword={resetToken}";

              
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("gsvpatel08@gmail.com", "Online Food Delivery"),
                    Subject = "Password Reset Request",
                    Body = $"<p>Hello,</p>" +
                           $"<p>We received a request to reset your password. Please click the link below to reset your password:</p>" +
                           $"<a href='{resetLink}'>Reset Password</a>" +
                           $"<p>If you did not request this, please ignore this email.</p>" +
                           $"<p>Thanks,<br>Your App Team</p>",
                    IsBodyHtml = true
                };

                mailMessage.To.Add(email);

                
                using var smtpClient = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("gsvpatel08@gmail.com", "gdpo qdeo adku wcbq"), 
                    EnableSsl = true
                };

                // Step 4: Send the email
                await smtpClient.SendMailAsync(mailMessage);
                Console.WriteLine("Reset password email sent successfully.");
            }
            catch (SmtpException smtpEx)
            {
                // Handle SMTP exceptions
                Console.WriteLine($"SMTP error occurred: {smtpEx.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Console.WriteLine($"Failed to send email: {ex.Message}");
                throw;
            }
        }
    }
}
