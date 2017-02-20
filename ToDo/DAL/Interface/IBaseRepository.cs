﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Interface
{
	public interface IBaseRepository<TEntity>
		where TEntity : class
	{
		IQueryable<TEntity> All { get; }

		IEnumerable<TEntity> Get(
			Expression<Func<TEntity, bool>> filter = null,
			Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
			string includeProperties = ""
		);

		TEntity Insert(TEntity entity);

		void Update(TEntity entityToUpdate);

		void SetStateModified(TEntity entity);
	}
}