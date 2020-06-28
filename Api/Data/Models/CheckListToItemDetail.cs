using System.Collections.Generic;

namespace Api.Data.Models
{
    public class CheckListToItemDetail
    {
        public int CheckListId { get; set; }
        public int ItemDetailId {get; set; }

        // Navigational Properties
        public CheckList CheckList { get; set; }
        public ItemDetail ItemDetail { get; set; }
    }
}
