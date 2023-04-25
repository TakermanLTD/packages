using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Takerman.Mail
{
    public class MailService : IMailService
    {
        public void SendToQueue(MailMessageDto mailMessage, RabbitMqConfig rabbitMqConfig)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailMessage));

            var rabbitMq = new ConnectionFactory()
            {
                HostName = rabbitMqConfig.Hostname,
                UserName = rabbitMqConfig.Username,
                Password = rabbitMqConfig.Password,
                Port = rabbitMqConfig.Port,
                DispatchConsumersAsync = true
            }.CreateConnection();

            var channel = rabbitMq.CreateModel();

            channel.BasicPublish(
                exchange: rabbitMqConfig.Exchange,
                routingKey: rabbitMqConfig.RoutingKey,
                mandatory: false,
                basicProperties: null,
                body: body);
        }
    }
}