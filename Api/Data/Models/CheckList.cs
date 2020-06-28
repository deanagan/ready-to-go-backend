using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.Models
{
    public class CheckList
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set;}

        // Navigational Property
        public ICollection<CheckListToItemDetail> CheckListToItems { get; set; }
    }
}
