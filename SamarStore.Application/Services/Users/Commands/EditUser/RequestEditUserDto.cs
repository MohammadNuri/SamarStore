namespace SamarStore.Application.Services.Users.Commands.EditUser
{
        public class RequestEditUserDto
        {
            public long UserId { get; set; }
            public string Fullname { get; set; } = string.Empty;    
            public string Email { get; set; } = string.Empty;   
        }

}
