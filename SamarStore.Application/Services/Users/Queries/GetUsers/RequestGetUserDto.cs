namespace SamarStore.Application.Services.Users.Queries.GetUsers
{
    public class RequestGetUserDto
    {
        public string SearchKey { get; set; } = string.Empty;   
        public int Page { get; set; }
    }
}
