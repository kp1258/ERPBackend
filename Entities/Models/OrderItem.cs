using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Models
{
    public class CustomOrderItem
    {
        public int CustomOrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int CustomProductId { get; set; }
        public CustomProduct CustomProduct { get; set; }
        [Required]
        public int Quantity { get; set; }
    }

    public class StandardOrderItem
    {
        public int StandardOrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
        [Required]
        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}