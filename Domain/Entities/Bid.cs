namespace Domain.Entities
{
    public class Bid
    {
        //fields
        public int Id { get; set; }

        //links
        public virtual User User { get; set; }
        public virtual Item Item { get; set; }
    }
}
