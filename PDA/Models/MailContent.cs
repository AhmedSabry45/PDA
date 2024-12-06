namespace PDA.Models
{
   
        public class MailContent
        {
            public string To { get; set; }
            public string? Cc { get; set; }
            public string? Bcc { get; set; }
            public string Subject { get; init; }
            public string Body { get; set; }
            public bool IsHTMLBody { get; set; }
        }

    public class MailSettings
    {
        public string DisplayName { get; init; }
        public string Email { get; init; }
        public string Host { get; init; }
        public int Port { get; init; }
        public string? Password { get; init; }
    }

}
