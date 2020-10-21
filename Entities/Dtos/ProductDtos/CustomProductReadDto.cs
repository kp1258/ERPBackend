using System;
using ERPBackend.Entities.Dtos.UserDtos;

namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class CustomProductReadDto
    {
        public int CustomProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UserInfoDto Technologist { get; set; }
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime PreparationStartDate { get; set; }
        public DateTime PreparationCompletionDate { get; set; }
    }
}