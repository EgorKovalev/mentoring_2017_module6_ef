using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Implementations;

namespace Wrapper
{
	public class Repository : IDisposable
	{
		private DatabaseContext _dbContext = new DatabaseContext();
		private EfGenericRepository<Item> _itemRepository;
		private EfGenericRepository<User> _userRepository;
		private EfGenericRepository<Project> _projectRepository;

		public EfGenericRepository<Item> ItemRepository
		{
			get
			{

				if (this._itemRepository == null)
				{
					this._itemRepository = new EfGenericRepository<Item>(_dbContext);
				}
				return _itemRepository;
			}
		}

		public EfGenericRepository<User> UserRepository
		{
			get
			{

				if (this._userRepository == null)
				{
					this._userRepository = new EfGenericRepository<User>(_dbContext);
				}
				return _userRepository;
			}
		}

		public EfGenericRepository<Project> ProjectRepository
		{
			get
			{

				if (this._projectRepository == null)
				{
					this._projectRepository = new EfGenericRepository<Project>(_dbContext);
				}
				return _projectRepository;
			}
		}

		public void CommitChanges()
		{
			_dbContext.SaveChanges();
		}

		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
