namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserReadDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}