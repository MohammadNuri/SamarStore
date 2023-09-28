using SamarStore.Domain.Entities.Commons;

namespace SamarStore.Domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public long Id { get; set; }    
        public string Name { get; set; }    
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
