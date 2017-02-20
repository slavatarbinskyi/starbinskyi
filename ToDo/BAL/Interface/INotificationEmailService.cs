namespace BAL.Interface
{
	public interface INotificationEmailService
	{
		bool NotifyOnEmail(string email, string password);
	}
}