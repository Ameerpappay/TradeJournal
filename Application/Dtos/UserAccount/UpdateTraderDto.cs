namespace Application.Dtos.UserAccount
{
    public class UpdateTraderDto : CreateUserDto
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
    }
}
