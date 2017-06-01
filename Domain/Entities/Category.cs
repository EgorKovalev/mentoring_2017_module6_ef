using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            Items = new List<Item>();
        }

        //fields
        public int Id { get; set; }
        public string Name { get; set; }

        //links
        public virtual ICollection<Item> Items { get; set; }
    }
}
