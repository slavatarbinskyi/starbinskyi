using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAL.Interface;

namespace BAL.Manager
{
	public class NotificationService:BaseManager,INotificationService
	{
		public NotificationService(IUnitOfWork uOW) : base(uOW)
		{
		}

		public bool NotifyOnEmail(string email, string password)
		{
			var _email = email;
			var pass = password;
			var items=uOW.ToDoItemRepo.All.Where(i=>i.IsNotify==true)
			using (SmtpClient client = new SmtpClient())
			{
				client.EnableSsl = true;
				client.Port = 587;
				client.Host = "smtp.gmail.com";
				client.UseDefaultCredentials = false;

				client.Credentials = new NetworkCredential(_email, pass);
				client.DeliveryMethod = SmtpDeliveryMethod.Network;
				var from = _email;
				//var to = model.Email;
				MailMessage message = new MailMessage(from, to);
				message.Subject = "Notify item to ToDo";
				message.IsBodyHtml = true;

				client.Send(message);
			}
			return true;
		}
	}
}
