using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Dtos.ClientDtos
{
    public class ClientPatchDto
    {
        [Required]
        public string Status { get; set; }
    }
}