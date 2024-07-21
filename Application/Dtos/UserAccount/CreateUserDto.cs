namespace Application.Dtos.UserAccount
{
    public abstract class CreateUserDto
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
