using MimeKit;

namespace Email.Core
{
    public interface IMessageContent
    {
        MimeEntity ToBody();
    }
}