using System.Threading.Tasks;
using MimeKit;

namespace Email.Core
{
    public interface IEmailClient
    {
        Task Send(MimeMessage message);
    }
}