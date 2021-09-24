using MimeKit;

namespace Email.Core
{
    public interface IMimeable
    {
        MimeMessage ToMimeMessage();
    }
}