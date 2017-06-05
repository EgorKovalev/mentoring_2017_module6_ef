using Wrapper;
using Domain.Entities;

namespace CodeFirst
{
    class Program
	{
		static void Main(string[] args)
		{
			Repository context = new Repository();

            User testUser = context.UserRepository.Add(new User()
            {
                Name = "Test user",
                Login = "Test",
                Email = "test.email@email.com",
                Password = "123456",
                Phone = "1234567"
            });

            //Auction testAuction = new Auction()
            //{
            //    Name = "Test auction",
            //    Description = "Auction description",
            //    Users = context.UserRepository.Get().Where(user => user.Name.Equals(testUser.Name)).ToList()
            //};
            //context.AuctionRepository.Add(testAuction);

            //Item testItem = new Item()
            //{
            //    Name = "Test item",
            //    Description = "Item description",
            //    Auction = testAuction                                
            //};
            //context.ItemRepository.Add(testItem);

            //Bid testBid = new Bid()
            //{
            //    Item = testItem,
            //    User = testUser
            //};
            //context.BidRepository.Add(testBid);            

            context.CommitChanges();
		}
	}
}