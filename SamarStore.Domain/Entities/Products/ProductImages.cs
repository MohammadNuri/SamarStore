using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamarStore.Domain.Entities.Commons;

namespace SamarStore.Domain.Entities.Products
{
    public class ProductImages : BaseEntity
    {
        public virtual Product Product { get; set; } // Ertebat Chand be 1 ba Product 
        public long ProductId { get; set; }
        public string Src { get; set; } = string.Empty; 
    }
}
