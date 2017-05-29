﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model.Interfaces
{
	interface IRepository<T>
	{
		IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

		T GetById(object id);
		
		T Add(T entity);

		void Delete(object id);

		void Delete(T entityToDelete);

		void Update(T entityToUpdate);
	}
}
