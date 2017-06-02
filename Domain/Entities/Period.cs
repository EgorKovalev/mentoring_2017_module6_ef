using System;

namespace Domain.Entities
{
    public class Period
    {
        //fileds
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Term { get; set; }

        //links
        //public virtual Item Item { get; set; }
        //public virtual Auction Auction { get; set; }
    }
}
