using System;
using System.Linq;
using BAL.Interface;
using DAL.Interface;
using Model.DB;

namespace BAL.Manager
{
	public class InviteUserManager : BaseManager, IInviteUserManager
	{
		public InviteUserManager(IUnitOfWork uOW) : base(uOW)
		{
		}

		public InviteUser GetByGuId(string guid)
		{
			return uOW.InviteUserRepo.All.Where(i => i.GuidId == guid).FirstOrDefault();
		}

		public void Insert(InviteUser user)
		{
			if (user == null) return;
			uOW.InviteUserRepo.Insert(user);
			uOW.Save();
		}

		public void Remove(int? id)
		{
			if (id == null) return;
			var user = new InviteUser
			{
				Id = id.Value
			};

			uOW.InviteUserRepo.Delete(user);
			uOW.Save();
		}

		public void Update(InviteUser user)
		{
			var userDb = uOW.InviteUserRepo.GetByID(user.Id);
			if (userDb == null) return;
			userDb.Email = user.Email;
			userDb.GuidId = user.GuidId;
			uOW.Save();
		}

		public string CreateInvite(InviteUser user)
		{
			if (user == null) return null;
			user.GuidId = Guid.NewGuid().ToString();
			uOW.InviteUserRepo.Insert(user);
			uOW.Save();
			return user.GuidId;
		}
	}
}