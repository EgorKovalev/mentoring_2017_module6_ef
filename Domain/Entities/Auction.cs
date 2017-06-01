using System.Collections.Generic;

namespace Domain.Entities
{
    public class Auction
    {
        public Auction()
        {
            Users = new List<User>();
            Items = new List<Item>();
        }

        //fields
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //links
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
