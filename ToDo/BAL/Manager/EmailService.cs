using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using BAL.Interface;
using Model.DB;
using System.Net.Mail;
using System.Net;

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

			using (SmtpClient client = new SmtpClient())
			{
				client.EnableSsl = true;
				client.Port = 587;
				client.Host = "smtp.gmail.com";
				client.UseDefaultCredentials = false;

				client.Credentials = new NetworkCredential(_email, pass);
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				string bodymail="To login on todoweb follow the link " + link;
				var from = _email;
				var to = model.Email;
				MailMessage message = new MailMessage(from, to);
				message.Subject = "Invite to ToDo";
				message.IsBodyHtml = true;
				message.Body = bodymail;

				client.Send(message);
			}
			return true;
		}
	}
}
