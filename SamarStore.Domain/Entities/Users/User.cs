using SamarStore.Domain.Entities.Commons;

namespace SamarStore.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;    
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;    
        public bool IsActive { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();
	}
}
