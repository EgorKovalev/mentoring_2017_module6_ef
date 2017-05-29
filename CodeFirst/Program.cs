using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Model.Implementations;
using Model.Interfaces;

namespace CodeFirst
{
	class Program
	{
		static void Main(string[] args)
		{
			DatabaseContext context = new DatabaseContext();
			EfItemRepository itemRepository = new EfItemRepository(context);
			EfProjectRepository projectRepository = new EfProjectRepository(context);
			EfUserRepository userRepository = new EfUserRepository(context);

			User user1 = userRepository.Add(new User()
			{
				Name = "Test name",
				Role = Role.Developer,
			});	

			var project1 = new Project()
			{
				Name = "Test project",
				Users = userRepository.Get().Where(user => user.Name.Equals(user1.Name)).ToList()
			};
			projectRepository.Add(project1);

			user1.Projects.Add(project1);			

			var item1 = new Item()
			{
				Name = "Test item",
				Project = project1,
				User = user1
			};

			itemRepository.Add(item1);			
			itemRepository.CommitChanges();
		}
	}
}