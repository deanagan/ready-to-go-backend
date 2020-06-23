using System.Collections.Generic;

namespace Api.Data.Models
{
    public class CheckListView
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ItemView> Items { get; set; }
    }
}
