using System.ComponentModel.DataAnnotations;

namespace Api.Data.Models
{
    public class ItemDetail
    {
        [Key]
        public int Id { get; set; }
        public bool Ready { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
