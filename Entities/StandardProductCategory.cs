using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ERPBackend.Entities
{
    public class StandardProductCategory
    {
        public int StandardProductCategoryId { get; set; }
        [Required]
        [MaxLength(20)]
        public string CategoryName { get; set; }
        public ICollection<StandardProduct> StandardProducts { get; set; }
    }
}