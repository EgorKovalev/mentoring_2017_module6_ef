using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Interfaces;

namespace Model.Implementations
{
	public class EfUserRepository : IRepository<User>
	{
		readonly DatabaseContext _dbContext;

		public EfUserRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<User> Get()
		{
			return _dbContext.Users;
		}
		
		public User Add(User ob)
		{
			return _dbContext.Users.Add(ob);						
		}
		
		public User Delete(int id)
		{
			User user = _dbContext.Users.FirstOrDefault(u => u.Id == id);
			return _dbContext.Users.Remove(user);
		}

		public void CommitChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
