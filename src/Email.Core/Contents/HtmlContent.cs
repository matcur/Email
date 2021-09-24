using MimeKit;

namespace Email.Core.Contents
{
    public class HtmlContent : IMessageContent
    {
        private readonly string _value;

        public HtmlContent(string value)
        {
            _value = value;
        }
        
        public MimeEntity ToBody()
        {
            return new TextPart("html") {Text = _value};
        }
    }
}