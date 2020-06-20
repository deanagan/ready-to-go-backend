using System.Collections.Generic;

namespace Api.Data.Models
{
    // Adding this class to represent one to many relationship between checklist and items.
    public class CheckListToItem
    {
        public int CheckListId { get; set; }
        public int ItemId {get; set; }

        // Navigational Properties
        public CheckList CheckList { get; set; }
        public Item Item { get; set; }
    }
}
