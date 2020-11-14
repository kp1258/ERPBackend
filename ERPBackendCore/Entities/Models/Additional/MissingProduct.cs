namespace ERPBackend.Entities.Models.Additional
{
    public class MissingProduct
    {

        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }
        public int Quantity { get; set; }
    }
}