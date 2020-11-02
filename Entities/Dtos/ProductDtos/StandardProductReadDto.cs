namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductReadDto
    {
        public int StandardProductId { get; set; }
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public string Status { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public StandardProductCategoryDto StandardProductCategory { get; set; }
    }
}