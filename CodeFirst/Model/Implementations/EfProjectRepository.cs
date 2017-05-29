using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Interfaces;

namespace Model.Implementations
{
	public class EfProjectRepository : IRepository<Project>
	{
		readonly DatabaseContext _dbContext;

		public EfProjectRepository(DatabaseContext dbContext)
		{
			_dbContext = dbContext;
		}

		public IEnumerable<Project> Get() 
		{
			return _dbContext.Projects;
		}

		public Project Add(Project ob)
		{
			return _dbContext.Projects.Add(ob);
		}

		public Project Delete(int id)
		{
			Project user = _dbContext.Projects.FirstOrDefault(u => u.Id == id);
			return _dbContext.Projects.Remove(user);
		}

		public void CommitChanges()
		{
			_dbContext.SaveChanges();
		}
	}
}
