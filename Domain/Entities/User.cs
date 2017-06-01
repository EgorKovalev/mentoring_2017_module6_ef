using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public User()
        {
            Auctions = new List<Auction>();
            Bids = new List<Bid>();
        }

        //fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //links
        public virtual ICollection<Auction> Auctions { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
    }
}
