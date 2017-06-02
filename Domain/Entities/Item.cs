using System.Collections.Generic;

namespace Domain.Entities
{
    public class Item
    {
        public Item()
        {
            Bids = new List<Bid>();
            //Images = new List<Image>();
        }

        //fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //links
        public virtual Auction Auction { get; set; }
        //public virtual Category Category { get; set; }
        //public virtual Period Period { get; set; }
        public virtual ICollection<Bid> Bids { get; set; }
        //public virtual ICollection<Image> Images { get; set; }
    }
}
