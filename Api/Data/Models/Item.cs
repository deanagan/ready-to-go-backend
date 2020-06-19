using System.Collections.Generic;

namespace Api.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        // Navigational Property
        public ICollection<CheckListToItem> CheckListToItems { get; set; }

        public ItemDetail ItemDetail { get; set; }
    }
}
