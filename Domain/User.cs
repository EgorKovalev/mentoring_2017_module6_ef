using System.Collections.Generic;

namespace Domain
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

		public User()
		{
			Projects = new List<Project>();
			Items = new List<Item>();
		}

		public virtual ICollection<Item> Items { get; set; }
		public virtual ICollection<Project> Projects { get; set; }
		public virtual Role Role { get; set; }
	}
}
