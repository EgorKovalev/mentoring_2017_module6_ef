using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Interfaces;

namespace Model.Implementations
{
	public class EfItemRepository : IRepository<Item>
	{
		readonly DatabaseContext _dbContext;

		public EfItemRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Item> Get()
		{
			return _dbContext.Items;
		}

		public Item Add(Item ob)
		{
			return _dbContext.Items.Add(ob);
		}

		public Item Delete(int id)
		{
			Item user = _dbContext.Items.FirstOrDefault(u => u.Id == id);
			return _dbContext.Items.Remove(user);
		}

		public void CommitChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
