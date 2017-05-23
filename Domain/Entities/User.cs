using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
	public enum Role
	{
		Developer = 1,
		QA,
		Manager
	}

	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<Item> Items { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
		public virtual Role Role { get; set; }
	}
}
