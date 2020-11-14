using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderPatchDto
    {
        [Required]
        public string Status { get; set; }
    }
}