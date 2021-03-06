﻿using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using DAL.Interface;
using DAL.Repositories;
using Model.DB;

namespace DAL
{
	public class UnitOfWork : IUnitOfWork, IDisposable
	{
		private MainContext context;

		public UnitOfWork()
		{
			context = new MainContext();
			inviteUserRepo = new GenericRepository<InviteUser>(context);
			userRepo = new GenericRepository<User>(context);
			toDoItemRepo = new GenericRepository<ToDoItem>(context);
			toDoListRepo = new GenericRepository<ToDoList>(context);
			tagRepo = new GenericRepository<Tag>(context);
			tagToDoListsRepo = new GenericRepository<TagToDoLists>(context);
		}

		public int Save()
		{
			try
			{
				UpdateTrackedEntities();
				return context.SaveChanges();
			}
			catch (DbEntityValidationException ex)
			{
				return 0;
			}
		}

		public void UpdateContext()
		{
			context = new MainContext();
		}

		private void UpdateTrackedEntities()
		{
			var entities = context.ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

			foreach (var ent in entities)
				((BaseEntity) ent.Entity).Modified = DateTime.UtcNow;
		}

		#region Private Repositories

		private IGenericRepository<User> userRepo;
		private IGenericRepository<ToDoItem> toDoItemRepo;
		private IGenericRepository<ToDoList> toDoListRepo;
		private IGenericRepository<InviteUser> inviteUserRepo;
		private IGenericRepository<Tag> tagRepo;
		private IGenericRepository<TagToDoLists> tagToDoListsRepo;

		#endregion Private Repositories

		#region Repositories Getters

		public IGenericRepository<TagToDoLists> TagToDoListsRepo
		{
			get
			{
				if (tagToDoListsRepo == null) tagToDoListsRepo = new GenericRepository<TagToDoLists>(context);
				return tagToDoListsRepo;
			}
		}

		public IGenericRepository<Tag> TagRepo
		{
			get
			{
				if (tagRepo == null) tagRepo = new GenericRepository<Tag>(context);
				return tagRepo;
			}
		}

		public IGenericRepository<InviteUser> InviteUserRepo
		{
			get
			{
				if (inviteUserRepo == null) inviteUserRepo = new GenericRepository<InviteUser>(context);
				return inviteUserRepo;
			}
		}

		public IGenericRepository<User> UserRepo
		{
			get
			{
				if (userRepo == null) userRepo = new GenericRepository<User>(context);
				return userRepo;
			}
		}

		public IGenericRepository<ToDoItem> ToDoItemRepo
		{
			get
			{
				if (toDoItemRepo == null) toDoItemRepo = new GenericRepository<ToDoItem>(context);
				return toDoItemRepo;
			}
		}

		public IGenericRepository<ToDoList> ToDoListRepo
		{
			get
			{
				if (toDoListRepo == null) toDoListRepo = new GenericRepository<ToDoList>(context);
				return toDoListRepo;
			}
		}

		#endregion Repositories Getters

		#region Dispose

		// https://msdn.microsoft.com/ru-ru/library/system.idisposable(v=vs.110).aspx

		private bool disposed;

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
				if (disposing)
					context.Dispose();
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion Dispose
	}
}