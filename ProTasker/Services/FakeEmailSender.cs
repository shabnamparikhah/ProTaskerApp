using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace ProTasker.Services
{
    public class FakeEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            
            Console.WriteLine($"SendEmailAsync called: {email} - {subject}");
            return Task.CompletedTask;
        }
    }
}
