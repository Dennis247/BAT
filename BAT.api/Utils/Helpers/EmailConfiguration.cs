using SendGrid.Helpers.Mail;

namespace BAT.api.Utils.Helpers
{
    public class EmailConfiguration
    {
        public string From { get; set; }   
        public string Name { get; set; }
        public string SendGridKey { get; set; }
    }

    public class Message
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string HtmlContent { get; set; }
        public string PlainContent { get; set; }

        public List<Attachment> Attachments { get; set; }

    
    }
}
