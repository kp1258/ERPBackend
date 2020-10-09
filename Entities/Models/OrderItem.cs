namespace ERPBackend.Entities.Models
{
    public class CustomOrderItem
    {
        public int CustomOrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CustomProductId { get; set; }
        public CustomProduct CustomProduct { get; set; }

        public int Quantity { get; set; }
    }

    public class StandardOrderItem
    {
        public int StandardOrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }

        public int Quantity { get; set; }
    }
}