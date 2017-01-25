using Model.DB;
using System.Data.Entity;

namespace DAL
{
	public class MainContext : DbContext
	{
		public MainContext()
			: base("MyToDo")
		{
			this.Configuration.LazyLoadingEnabled = false;
			this.Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<ToDoItem> Items { get; set; }
		public DbSet<ToDoList> Lists { get; set; }
		public DbSet<User> Users { get; set; }
	}
}