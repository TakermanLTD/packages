﻿namespace Takerman.Mail
{
    public class RabbitMqConfig
    {
        public string Hostname { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int Port { get; set; }

        public string Exchange { get; set; }

        public string Queue { get; set; }

        public string RoutingKey { get; set; }
    }
}