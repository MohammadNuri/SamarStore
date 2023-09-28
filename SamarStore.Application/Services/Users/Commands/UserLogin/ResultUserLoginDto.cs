namespace SamarStore.Application.Services.Users.Commands.UserLogin
{
    public class ResultUserLoginDto
    {
        public long UserId { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
    }
}
