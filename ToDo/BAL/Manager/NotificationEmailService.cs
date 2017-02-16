using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using BAL.Interface;
using DAL;
using DAL.Interface;
using Model.DTO;

namespace BAL.Manager
{
	public class NotificationEmailService : BaseManager, INotificationEmailService
	{
		public NotificationEmailService(IUnitOfWork uOW) : base(uOW)
		{
		}

		public bool NotifyOnEmail(string email, string password)
		{
			var _email = email;
			var pass = password;
			var notifyItems = uOW.ToDoItemRepo.Get(includeProperties: "ToDoList.User").Where(i => i.IsNotify == true && i.NextNotifyTime<DateTime.UtcNow).ToList();

			List<NotifyDTO> result = new List<NotifyDTO>();
			foreach (var item in notifyItems)
			{
				NotifyDTO notifyItem = new NotifyDTO() { ItemName = item.Text, ListName = item.ToDoList.Name, NotifyTime = item.NextNotifyTime.Value, Email = item.ToDoList.User.Email };
				result.Add(notifyItem);
			}
			foreach (var notify in result)
			{

					using (SmtpClient client = new SmtpClient())
					{
						client.EnableSsl = true;
						client.Port = 587;
						client.Host = "smtp.gmail.com";
						client.UseDefaultCredentials = false;

						client.Credentials = new NetworkCredential(_email, pass);
						client.DeliveryMethod = SmtpDeliveryMethod.Network;
						var from = _email;
						var to = notify.Email;
						MailMessage message = new MailMessage(from, to);
						message.Subject = "Notify todo";
						message.Body = "Notify item to ToDo in list: " + notify.ListName + "item : " + notify.ItemName;
						message.IsBodyHtml = true;

						client.Send(message);
						var toDoItemManager = new ToDoItemManager(new UnitOfWork());
						toDoItemManager.MarkAsNotified(notify.ItemName);
					}
				return true;
			}
			return true;
		}
	}
}
