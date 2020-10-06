using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERPBackend.Entities.Models
{
    public class StandardProductItem
    {
        public int StandardProductItemId { get; set; }
        [Required]
        public int Quantity { get; set; }

        public int StandardProductId { get; set; }
        public StandardProduct StandardProduct { get; set; }
    }
}