namespace ERPBackend.Entities.Dtos.UserDtos
{
    public class UserPasswordUpdateDto
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}