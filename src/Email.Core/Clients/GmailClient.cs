using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace Email.Core.Clients
{
    public class GmailClient : IEmailClient
    {
        private readonly string _name;
        
        private readonly string _email;

        private readonly string _password;

        private readonly MailTransport _transport;

        public GmailClient(string name, string email, string password)
            : this(name, email, password, new SmtpClient())
        {

        }

        public GmailClient(string name, string email, string password, MailTransport transport)
        {
            _name = name;
            _email = email;
            _password = password;
            _transport = transport;
        }
        
        public async Task Send(MimeMessage message)
        {
            message.From.Add(new MailboxAddress(_name, _email));
            using (_transport)
            {
                await _transport.ConnectAsync("smtp.gmail.com", 587, false);
                await _transport.AuthenticateAsync(_email, _password);

                await _transport.SendAsync(message);
                
                await _transport.DisconnectAsync(true);
            }
        }
    }
}
