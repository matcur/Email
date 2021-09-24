using MimeKit;

namespace Email.Core.Contents
{
    public class TextContent : IMessageContent
    {
        private readonly string _value;

        public TextContent(string value)
        {
            _value = value;
        }
        
        public MimeEntity ToBody()
        {
            return new TextPart("plaint") {Text = _value};
        }
    }
}