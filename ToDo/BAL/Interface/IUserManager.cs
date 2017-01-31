using Model.DB;
using System.Collections.Generic;

namespace BAL.Interface
{
    public interface IUserManager
    {
        void UpdateUser(User user);
        List<User> GetAll();

        void Insert(User user);
		bool EmailIsExist(string email);
		User GetByEmail(string email);
		void RemoveUser(User user);
		User Find(string username, string password);
		User GetById(int id);

	}
}