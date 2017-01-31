using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
	public interface IEmailService
	{
		 bool SendEmail(User model,string link, string email, string password);
	}
}
