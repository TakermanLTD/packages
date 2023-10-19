using System.Net.Mail;
using System.Threading.Tasks;

namespace Takerman.Mail
{
    public interface IMailService
    {
        Task SendToQueue(MailMessage message);
    }
}