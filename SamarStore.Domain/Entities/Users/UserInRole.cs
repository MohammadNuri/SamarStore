using SamarStore.Domain.Entities.Commons;

namespace SamarStore.Domain.Entities.Users
{
    public class UserInRole : BaseEntity 
    {
		public virtual User User { get; set; }
		public long UserId { get; set; }
		public virtual Role Role { get; set; }  
        public long RoleId { get; set; }    
    }
}
