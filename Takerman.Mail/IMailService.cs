namespace Takerman.Mail
{
    public interface IMailService
    {
        void SendToQueue(MailMessageDto mailMessage, RabbitMqConfig rabbitMqConfig);
    }
}