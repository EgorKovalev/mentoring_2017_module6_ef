using System.Linq;
using Domain;
using Wrapper;

namespace CodeFirst
{
    class Program
	{
		static void Main(string[] args)
		{
			Repository context = new Repository();

			User user1 = context.UserRepository.Add(new User()
			{
				Name = "Test name",
				Role = Role.Developer,
			});

			var project1 = new Project()
			{
				Name = "Test project",
				Users = context.UserRepository.Get().Where(user => user.Name.Equals(user1.Name)).ToList()
			};
			context.ProjectRepository.Add(project1);

			user1.Projects.Add(project1);

			var item1 = new Item()
			{
				Name = "Test item",
				Project = project1,
				User = user1
			};

			context.ItemRepository.Add(item1);
			context.CommitChanges();
		}
	}
}