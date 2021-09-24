namespace Email.Core
{
    public interface IMessage : IMessageContent, IMessageInformation, IMimeable
    {
    }
}