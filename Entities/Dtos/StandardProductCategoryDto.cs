namespace ERPBackend.Entities.Dtos
{
    public class StandardProductCategoryDto
    {
        public int StandardProductCategoryId { get; set; }
        public string Name { get; set; }
    }

    public class StandardProductCategoryUpdateDto
    {
        public string Name { get; set; }
    }

    public class StandardProductCategoryCreateDto
    {
        public string Name { get; set; }
    }
}