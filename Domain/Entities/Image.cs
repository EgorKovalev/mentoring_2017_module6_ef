namespace Domain.Entities
{
    public class Image
    {
        //fields
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }

        //links
        public virtual Item Item { get; set; }
    }
}
