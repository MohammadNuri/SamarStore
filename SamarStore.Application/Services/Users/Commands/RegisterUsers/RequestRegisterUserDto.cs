namespace SamarStore.Application.Services.Users.Commands.RegisterUsers
{
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string Password { get; set; } = string.Empty;    
        public string RePassword { get; set; } = string.Empty;  
        public List<RolesInRegisterUserDto> Roles { get; set; }
    }
}
