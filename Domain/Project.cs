using System.Collections.Generic;

namespace Domain
{
    public class Project
	{

		public Project()
		{
			Users = new List<User>();
			Items = new List<Item>();
		}

		public int Id { get; set; }
		public string Name { get; set; }

		public virtual ICollection<User> Users { get; set; }
		public virtual ICollection<Item> Items { get; set; }
	}
}
