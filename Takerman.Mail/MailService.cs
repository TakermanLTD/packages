using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Takerman.Mail.Queue;

namespace Takerman.Mail
{
    public class MailService : IMailService
    {
        private readonly RabbitMqConfig _rabbitMqConfig;
        private readonly ConnectionFactory _connectionFactory;

        public MailService(IOptions<RabbitMqConfig> rabbitMqConfig)
        {

            _rabbitMqConfig = rabbitMqConfig.Value;
            _connectionFactory = new ConnectionFactory()
            {
                HostName = _rabbitMqConfig.Hostname,
                UserName = _rabbitMqConfig.Username,
                Password = _rabbitMqConfig.Password,
                Port = _rabbitMqConfig.Port,
                DispatchConsumersAsync = true
            };
        }

        public async Task SendToQueue(MailMessage message)
        {
            var messageDto = new MailMessageDto()
            {
                From = message.From.Address,
                To = message.To.FirstOrDefault().Address,
                Body = message.Body,
                Subject = message.Subject
            };

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(messageDto));

            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    try
                    {
                        channel.ExchangeDeclare(DeadLetterQueue.Exchange, ExchangeType.Direct, durable: true, autoDelete: false);
                        channel.QueueDeclare(DeadLetterQueue.Queue, durable: true, exclusive: false, autoDelete: false);
                        channel.QueueBind(DeadLetterQueue.Queue, DeadLetterQueue.Exchange, DeadLetterQueue.RoutingKey);

                        channel.ExchangeDeclare(MailQueue.Exchange, ExchangeType.Direct, durable: false, autoDelete: false);
                        channel.QueueDeclare(MailQueue.Queue, durable: false, exclusive: false, autoDelete: false, DeadLetterQueue.Args);
                        channel.QueueBind(MailQueue.Queue, MailQueue.Exchange, MailQueue.RoutingKey);

                        channel.BasicPublish(
                            exchange: MailQueue.Exchange,
                            routingKey: MailQueue.RoutingKey,
                            mandatory: false,
                            basicProperties: null,
                            body: body);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Exception while publishing a message", ex);
                    }
                    finally
                    {
                        channel.Close();
                        connection.Close();
                        channel.Dispose();
                        connection.Dispose();
                    }
                }
            }
        }
    }
}