using System;
using System.Collections.Generic;
using ERPBackend.Entities.Dtos.ClientDtos;
using ERPBackend.Entities.Dtos.ProductDtos;
using ERPBackend.Entities.Dtos.UserDtos;

namespace ERPBackend.Entities.Dtos.AdditionalDtos
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public DateTime PlacingDate { get; set; }
        public DateTime RealizationStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public ClientInfoDto Client { get; set; }
        public UserInfoDto Salesman { get; set; }
        public UserInfoDto Warehouseman { get; set; }
        public IEnumerable<CustomOrderItemReadDto> CustomOrderItems { get; set; }
        public IEnumerable<StandardOrderItemDetailDto> StandardOrderItemDetails { get; set; }
    }

    public class StandardOrderItemDetailDto
    {
        public int StandardOrderItemId { get; set; }
        public StandardProductReadDto StandardProduct { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int MissingQuantity { get; set; }
    }
}