using Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BusinessLayerAccess.Implementations
{
    public class DatabaseContext : DbContext
	{
		public DatabaseContext()
			: base("name=ProjectDB1") { }

		public DbSet<Auction> Auctions { get; set; }
		public DbSet<Bid> Bids { get; set; }
		public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
