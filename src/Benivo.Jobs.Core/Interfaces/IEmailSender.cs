using System.Threading.Tasks;

namespace Benivo.Jobs.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
