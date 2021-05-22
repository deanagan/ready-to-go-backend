using System.Collections.Generic;

namespace Api.Data.Models
{
    public class ItemDetail
    {
        public int Id { get; set; }
        public bool Ready { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }

        public ICollection<CheckListToItemDetail> CheckListToItems { get; set; }
    }
}
