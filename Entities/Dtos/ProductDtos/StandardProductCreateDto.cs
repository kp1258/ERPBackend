namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductCreateDto
    {
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public StandardProductCategoryDto StandardProductCategory { get; set; }
    }
}