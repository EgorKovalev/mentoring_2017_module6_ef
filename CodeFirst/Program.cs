using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Implementations;

namespace CodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var db = new DatabaseContext())
			{
				var FirstUser = new User()
				{
					Name = "Test name",
					Role = Role.Developer
				};

				db.Users.Add(FirstUser);
				db.SaveChanges();

				var FirstProject = new Project()
				{
					Name = "Test project",
					Users = db.Users.Where(user => user.Name.Equals(FirstUser.Name)).ToList()					
				};

				db.Projects.Add(FirstProject);
				db.SaveChanges();

				var FirstItem = new Item()
				{
					Name = "Test item",
					Project = FirstProject,
					User = FirstUser
				};

				db.Items.Add(FirstItem);
				db.SaveChanges();
			}
		}
	}
}