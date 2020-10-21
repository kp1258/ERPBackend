using System;

namespace ERPBackend.Entities.Dtos.OrderDtos
{
    public class OrderReadDto
    {
        public int OrderId;
        public DateTime PlacingDate { get; set; }
        public DateTime RealizationStartDate { get; set; }
        public DateTime CompletionDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }

    }
}