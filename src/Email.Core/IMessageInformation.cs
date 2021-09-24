using System.Collections.Generic;
using MimeKit;

namespace Email.Core
{
    public interface IMessageInformation
    {
        IEnumerable<MailboxAddress> Targets();
    }
}