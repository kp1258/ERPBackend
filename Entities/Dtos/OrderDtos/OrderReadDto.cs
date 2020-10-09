using System;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int OrderId;
        public DateTime PlacingDate { get; set; }
        public DateTime FulfillmentDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

    }
}