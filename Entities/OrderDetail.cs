namespace ERPBackend.Entities
{
    public class CustomOrderDetail
    {
        public int CustomOrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CustomProductId { get; set; }
        public CustomProduct CustomProduct { get; set; }

        public int Quantity { get; set; }
    }

    public class StandardOrderDetail
    {
        public int StandardOrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }

        public int Quantity { get; set; }
    }
}