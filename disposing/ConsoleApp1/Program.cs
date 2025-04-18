using System.Net.Mail;

MailAddress from = new MailAddress("newsletter-sender@mail.com");
MailAddress? to = null;

Console.WriteLine("Write you e-mail below to subscribe to our newsletter");

while (to == null)
{
    try
    {
        string? providedEmail = Console.ReadLine();
        to = new MailAddress(providedEmail);
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }
}

using (MailMessage message = new MailMessage(from, to))
using (SmtpClient client = new())
{
    message.Subject = "Newsletter Thanks";
    message.Body = "Thank you for subscribing to our newsletter!";

    try
    {
        client.Send(message);
    }
    catch (SmtpException e)
    {
        Console.WriteLine(e);
    }
}