namespace ERPBackend.Entities.Dtos.ProductDtos
{
    public class StandardProductUpdateDto
    {
        public string Name { get; set; }
        public string Dimensions { get; set; }
        public StandardProductCategoryDto standardProductCategory { get; set; }
    }
}