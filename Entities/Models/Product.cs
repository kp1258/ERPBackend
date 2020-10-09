using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace ERPBackend.Entities.Models
{
    public class StandardProduct
    {
        public int StandardProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public string Dimensions { get; set; }

        public int StandardProductCategoryId { get; set; }
        public StandardProductCategory StandardProductCategory { get; set; }

        public ICollection<StandardOrderItem> StandardOrderItem { get; set; }
        public StandardProductItem ProductItem { get; set; }

    }

    public class CustomProduct
    {
        public int CustomProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int TechnologistId { get; set; }
        public User Technologist { get; set; }

        public ICollection<CustomOrderItem> CustomOrderItems { get; set; }
    }
}
