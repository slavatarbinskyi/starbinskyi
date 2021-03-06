﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using NLog;

namespace DAL.Repositories
{
	public abstract class BaseRepository<TEntity> where TEntity : class
	{
		private readonly Logger _logger = LogManager.GetCurrentClassLogger();
		internal MainContext context;
		internal DbSet<TEntity> dbSet;

		public BaseRepository(MainContext context)
		{
			this.context = context;
			dbSet = context.Set<TEntity>();
		}

		public virtual IQueryable<TEntity> All
		{
			get { return dbSet; }
		}

		public virtual IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = "")
		{
			IQueryable<TEntity> query = dbSet;

			if (filter != null)
				query = query.Where(filter);

			foreach (var includeProperty in includeProperties.Split
				(new[] {','}, StringSplitOptions.RemoveEmptyEntries))
				query = query.Include(includeProperty);

			if (orderBy != null)
				return orderBy(query).ToList();
			return query.ToList();
		}

		public virtual TEntity Insert(TEntity entity)
		{
			return dbSet.Add(entity);
		}

		public virtual void Delete(TEntity entityToDelete)
		{
			if (context.Entry(entityToDelete).State == EntityState.Detached)
				dbSet.Attach(entityToDelete);
			dbSet.Remove(entityToDelete);
		}

		public virtual void Update(TEntity entityToUpdate)
		{
			try
			{
				dbSet.Attach(entityToUpdate);
			}
			catch
			{
				_logger.Error("Error while updating entity");
			}
			context.Entry(entityToUpdate).State = EntityState.Modified;
		}

		public void SetStateModified(TEntity entity)
		{
			context.Entry(entity).State = EntityState.Modified;
		}
	}
}