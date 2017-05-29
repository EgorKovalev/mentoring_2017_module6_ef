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
		readonly DatabaseContext _dbContext = new DatabaseContext();

		public IEnumerable<Item> Get { get; private set; }

		public Item Save(Item ob)
		{
			return _dbContext.Items.Add(ob);
		}

		public Item Delete(int id)
		{
			Item user = _dbContext.Items.FirstOrDefault(u => u.Id == id);
			return _dbContext.Items.Remove(user);
		}
	}
}
