namespace SamarStore.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersDto
    {
        public long Id { get; set; }
        public string FullName { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;   
        public bool IsActive { get; set; }
    }
}
