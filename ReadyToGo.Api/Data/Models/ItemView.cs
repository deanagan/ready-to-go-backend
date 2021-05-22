namespace Api.Data.Models
{
    public class ItemView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsReady { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
    }
}
