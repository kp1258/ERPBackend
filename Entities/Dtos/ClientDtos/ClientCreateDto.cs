namespace ERPBackend.Entities.Dtos.ClientDtos
{
    public class ClientCreateDto
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public AddressInfoDto Address { get; set; }

        public int SalesmanId { get; set; }
    }
}