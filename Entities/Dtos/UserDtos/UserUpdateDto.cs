namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
    }
}