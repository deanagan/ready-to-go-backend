using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.Data.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
