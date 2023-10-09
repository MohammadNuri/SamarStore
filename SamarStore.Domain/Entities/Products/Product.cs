using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamarStore.Domain.Entities.Commons;

namespace SamarStore.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }

        public virtual Category Category { get; set; } // Ertebat Chand be 1 ba Category 
        public long CategoryId { get; set; }
        public virtual ICollection<ProductImages> ProductImages { get; set; } // Ertebat 1 be Chand ba ProductImages
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; } // Ertebat 1 be Chand ba Product Features
    }
}
