using SamarStore.Domain.Entities.Commons;

namespace SamarStore.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public string Name { get; set; } = string.Empty; 
        public ICollection<UserInRole> UserInRoles { get; set; } = new List<UserInRole>();
    }
}
