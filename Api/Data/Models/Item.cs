using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int ItemDetailId { get; set; }

        // Navigational Property
        public ICollection<CheckListToItem> CheckListToItems { get; set; }

        public ItemDetail ItemDetail { get; set; }
    }
}
