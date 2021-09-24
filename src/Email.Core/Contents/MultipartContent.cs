using System.Collections.Generic;
using MimeKit;

namespace Email.Core.Contents
{
    public class MultipartContent : IMessageContent
    {
        private readonly IEnumerable<IMessageContent> _parts;

        public MultipartContent(IEnumerable<IMessageContent> parts)
        {
            _parts = parts;
        }
        
        public MimeEntity ToBody()
        {
            var multipart = new Multipart("mixed");
            foreach (var part in _parts)
            {
                multipart.Add(part.ToBody());
            }

            return multipart;
        }
    }
}