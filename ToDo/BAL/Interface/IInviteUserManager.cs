using Model.DB;

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