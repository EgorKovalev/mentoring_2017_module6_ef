using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Domain;

namespace Model.Implementations
{
    public class DatabaseContext : DbContext
	{
		public DatabaseContext()
			: base("name=ProjectDB1") { }

		public DbSet<User> Users { get; set; }
		public DbSet<Item> Items { get; set; }
		public DbSet<Project> Projects { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
