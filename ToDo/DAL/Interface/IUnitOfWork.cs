using Model.DB;

namespace DAL.Interface
{
	public interface IUnitOfWork
	{
		IGenericRepository<ToDoList> ToDoListRepo { get; }
		IGenericRepository<User> UserRepo { get; }
		IGenericRepository<ToDoItem> ToDoItemRepo { get; }
		IGenericRepository<InviteUser> InviteUserRepo { get; }

		void Dispose();

		int Save();
	}
}