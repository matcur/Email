using System.Collections.Generic;
using Email.Core.Contents;
using MimeKit;

namespace Email.Core
{
    public class EmailMessage : IMessage
    {
        private readonly IEnumerable<MailboxAddress> _receivers;
        
        private readonly IMessageContent _content;

        public EmailMessage(string toName, string toEmail, params IMessageContent[] contents)
            : this(new MailboxAddress(toName, toEmail), contents)
        {
        }

        public EmailMessage(MailboxAddress to, params IMessageContent[] contents)
            : this(new List<MailboxAddress> {to}, contents)
        {
        }

        public EmailMessage(IEnumerable<MailboxAddress> receivers, params IMessageContent[] contents)
            : this(receivers, new MultipartContent(contents))
        {
        }

        public EmailMessage(IEnumerable<MailboxAddress> receivers, IMessageContent content)
        {
            _receivers = receivers;
            _content = content;
        }
        
        public MimeEntity ToBody()
        {
            return _content.ToBody();
        }

        public IEnumerable<MailboxAddress> Targets()
        {
            return _receivers;
        }

        public MimeMessage ToMimeMessage()
        {
            var message = new MimeMessage
            {
                Body = ToBody(),
            };
            
            message.To.AddRange(_receivers);

            return message;
        }
    }
}