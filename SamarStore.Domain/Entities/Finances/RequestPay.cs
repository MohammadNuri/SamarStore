using SamarStore.Domain.Entities.Commons;
using SamarStore.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Domain.Entities.Finances
{
    public class RequestPay : BaseEntity
    {
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }

        //Relation with User
        public virtual User User { get; set; }
        public long UserId { get; set; }

        //ZarinPal Keys 
        public string Authority { get; set; } = string.Empty;
        public long RefId { get; set; } = 0;
    }
}
