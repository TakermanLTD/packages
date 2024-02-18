namespace Takerman.Mail
{
    public class MailMessageDto
    {
        public string Name { get; set; } = "User";

        public string From { get; set; }

        public string To { get; set; } = "tivanov@takerman.net";

        public string Subject { get; set; } = "New message from App";

        public string Body { get; set; }
    }
}