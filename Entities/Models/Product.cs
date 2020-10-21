using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace ERPBackend.Entities.Models
{
    public class StandardProduct
    {
        public int StandardProductId { get; set; }
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public string Dimensions { get; set; }
        [Required]
        public int StandardProductCategoryId { get; set; }
        public StandardProductCategory StandardProductCategory { get; set; }
        [Required]
        public StandardProductStatus Status { get; set; }

        public ICollection<StandardOrderItem> StandardOrderItem { get; set; }
        public ProductWarehouseItem ProductItem { get; set; }

    }
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StandardProductStatus
    {
        [EnumMember(Value = "produkowany")]
        InProduction,
        [EnumMember(Value = "wycofany z produkcji")]
        Discontinued
    }

    public class CustomProduct
    {
        public int CustomProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public CustomProductStatus Status { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? PreparationStartDate { get; set; }
        public DateTime? PreparationCompletionDate { get; set; }

        public int? TechnologistId { get; set; }
        public User Technologist { get; set; }

        public ICollection<CustomOrderItem> CustomOrderItems { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum CustomProductStatus
    {
        [EnumMember(Value = "zamówiony")]
        Ordered,
        [EnumMember(Value = "w przygotowaniu")]
        InPreparation,
        [EnumMember(Value = "przygotowany")]
        Prepared
    }
}
