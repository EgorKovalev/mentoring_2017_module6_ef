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
		readonly DatabaseContext _dbContext = new DatabaseContext();

		public IEnumerable<Project> Get { get; private set; }

		public Project Save(Project ob)
		{
			return _dbContext.Projects.Add(ob);
		}

		public Project Delete(int id)
		{
			Project user = _dbContext.Projects.FirstOrDefault(u => u.Id == id);
			return _dbContext.Projects.Remove(user);
		}
	}
}
