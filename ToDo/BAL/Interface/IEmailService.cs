using Model.DB;

namespace BAL.Interface
{
	public interface IEmailService
	{
		bool SendEmail(User model, string link, string email, string password);
	}
}