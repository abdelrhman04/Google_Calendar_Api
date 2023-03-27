
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;
using System.Net.Mail;
namespace Task
{
    public static class Email
    {
      public static async void sendMaile(string email,string message ="Create Event")
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("abdomajde04@gmail.com","aaaa");
            var subject = "Sending with SendGrid is Fun";
            var to = new EmailAddress(email, "Example User");
            var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent =$"<strong>{message}<trong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }  
    }
}