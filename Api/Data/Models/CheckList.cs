using System.Collections.Generic;


namespace Api.Data.Models
{
    public class CheckList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}

        // Navigational Property
        public ICollection<CheckListToItemDetail> CheckListToItems { get; set; }
    }
}
