﻿using Model.DB;
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
		public MainContext(string connString)
			: base(connString)
		{
			this.Configuration.LazyLoadingEnabled = false;
			this.Configuration.ProxyCreationEnabled = false;
		}

		public DbSet<ToDoItem> Items { get; set; }
		public DbSet<ToDoList> Lists { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<InviteUser> InviteUsers { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TagToDoLists> TagToDoLists { get; set; }
	}
}