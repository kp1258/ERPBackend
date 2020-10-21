namespace ERPBackend.Entities.Dtos.ClientDtos
{
    public class ClientUpdateDto
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EMail { get; set; }
        public AddressInfoDto Address { get; set; }
        public string Status { get; set; }
    }
}