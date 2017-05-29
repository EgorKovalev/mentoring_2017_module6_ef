using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Interfaces;

namespace Model.Implementations
{
	public class EfGenericRepository<T> : IRepository<T> where T : class
	{
		internal readonly DatabaseContext _dbContext;
		internal readonly DbSet<T> _dbSet;

		public EfGenericRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<T>();
		}

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
			IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual T GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual T Add(T entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = _dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
			if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
			_dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
	}
}
