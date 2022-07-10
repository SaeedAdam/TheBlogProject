using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace TheBlogProject.Services
{
    public interface IBlogEmailSender : IEmailSender
    {
        Task SendEmailAsync(string emailForm, string name, string subject, string htmlMessage);
    }
}
