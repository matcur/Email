using System.IO;
using MimeKit;

namespace Email.Core.Contents
{
    public class FileContent : IMessageContent
    {
        private readonly string _path;

        public FileContent(string path)
        {
            _path = path;
        }
        
        public MimeEntity ToBody()
        {
            return new MimePart
            {
                Content = new MimeContent(File.OpenRead(_path)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = Path.GetFileName(_path)
            };
        }
    }
}