using System.Threading.Tasks;

namespace Takerman.Mail
{
    public interface IMailService
    {
        Task SendToQueue(MailMessageDto message);
    }
}