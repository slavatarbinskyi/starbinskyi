using System.Net;
using System.Net.Mail;
using BAL.Interface;
using DAL.Interface;
using Model.DB;

namespace BAL.Manager
{
	public class EmailService : BaseManager, IEmailService
	{
		public EmailService(IUnitOfWork uOW) : base(uOW)
		{
		}

		public bool SendEmail(User model, string link, string email, string password)
		{
			var _email = email;
			var pass = password;

			using (var client = new SmtpClient())
			{
				client.EnableSsl = true;
				client.Port = 587;
				client.Host = "smtp.gmail.com";
				client.UseDefaultCredentials = false;

				client.Credentials = new NetworkCredential(_email, pass);
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				var bodymail = "To login on todoweb follow the link " + link;
				var from = _email;
				var to = model.Email;
				var message = new MailMessage(from, to);
				message.Subject = "Invite to ToDo";
				message.IsBodyHtml = true;
				message.Body = bodymail;

				client.Send(message);
			}
			return true;
		}
	}
}