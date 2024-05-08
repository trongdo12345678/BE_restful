using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BE_restful.Areas.AdminManager.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SendmailController : ControllerBase
{
    [HttpPost]
    public bool SendEmail(string Name, string Address, string EMail, string PhoneNumber, string Message)
    {
        string senderEmail = "anhbon148@gmail.com";
        string senderPassword = "rers hmoe ssut eltq";


        string smtpAddress = "smtp.gmail.com";
        int portNumber = 587;


        SmtpClient smtpClient = new SmtpClient(smtpAddress, portNumber);


        smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
        smtpClient.EnableSsl = true;


        MailMessage mail = new MailMessage();
        mail.From = new MailAddress(senderEmail);
        mail.To.Add(EMail);


        mail.Subject = "New message from your website";


        mail.Body = "Name: " + Name + "<br>" +
                    "Address: " + Address + "<br>" +
                    "Phone Number: " + PhoneNumber + "<br>" +
                    "Message: " + Message;

        mail.IsBodyHtml = true;

        try
        {
            smtpClient.Send(mail);

        }
        catch (Exception ex)
        {
            Debug.WriteLine("Failed to send email. Error message: " + ex.Message);
        }

        return true;

    }
}
