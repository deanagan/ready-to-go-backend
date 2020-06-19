
namespace Api.Data.Models
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Ready { get; set; }
        public int Quantity { get; set; }
        public Item Item { get; set; }
    }
}
