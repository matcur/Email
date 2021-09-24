using System;
using System.Threading.Tasks;
using Email.Core;
using Email.Core.Clients;
using Email.Core.Contents;

namespace Email.Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var message = new EmailMessage(
                "name",
                "******",
                new HtmlContent("<strong>Hi!!!</strong>"),
                new FileContent("appsettings.json")
            );

            await new GmailClient(
                "name",
                "*****", 
                "*****"
            ).Send(message.ToMimeMessage());
        }
    }
}