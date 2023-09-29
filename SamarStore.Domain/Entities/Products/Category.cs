using SamarStore.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Domain.Entities.Products
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual Category ParentCategory { get; set; }    
        public long? ParentCategoryId { get; set; }

        //for showing SubCategory of Categories 
        public virtual ICollection<Category> SubCategories { get; set; }
   
    }
}
