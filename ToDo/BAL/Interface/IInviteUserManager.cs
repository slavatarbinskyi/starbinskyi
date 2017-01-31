using Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface
{
	public interface IInviteUserManager
	{
		InviteUser GetByGuId(string guid);
		void Insert(InviteUser user);
		void Remove(int? id);
		void Update(InviteUser user);
		string CreateInvite(InviteUser user);
	}
}
