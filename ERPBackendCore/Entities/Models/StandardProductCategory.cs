using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities.Models
{
    public class StandardProductCategory
    {
        public int StandardProductCategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public ICollection<StandardProduct> StandardProducts { get; set; }
    }
}