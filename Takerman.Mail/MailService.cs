using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace Takerman.Mail
{
    public class MailService : IMailService
    {
        private RabbitMqConfig _rabbitMqConfig;

        public void SendToQueue(MailMessageDto mailMessage, RabbitMqConfig rabbitMqConfig)
        {
            _rabbitMqConfig = rabbitMqConfig;
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(mailMessage));

            var connectionFactory = new ConnectionFactory()
            {
                HostName = rabbitMqConfig.Hostname,
                UserName = rabbitMqConfig.Username,
                Password = rabbitMqConfig.Password,
                Port = rabbitMqConfig.Port,
                DispatchConsumersAsync = true
            };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    try
                    {
                        channel.QueueDeclare(_rabbitMqConfig.Queue, durable: false, exclusive: false, autoDelete: false);
                        channel.ExchangeDeclare(_rabbitMqConfig.Exchange, ExchangeType.Direct, durable: false, autoDelete: false);

                        channel.BasicPublish(
                            exchange: rabbitMqConfig.Exchange,
                            routingKey: rabbitMqConfig.RoutingKey,
                            mandatory: false,
                            basicProperties: null,
                            body: body);
                    }
                    catch (Exception ex)
                    {
                        var message = ex.Message + (ex.InnerException == null ? string.Empty : ex.InnerException.Message);
                        Console.WriteLine($"Exception while publishing a message in the package: {message}");
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