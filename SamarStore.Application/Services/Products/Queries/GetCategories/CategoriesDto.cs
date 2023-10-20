﻿namespace SamarStore.Application.Services.Products.Queries.GetCategories
{
    public class CategoriesDto 
    {
        public long Id { get; set; }   
        public string Name { get; set; } = string.Empty;    
        public bool HasChild { get; set; }
        public ParentCategoryDto Parent { get; set; }

    } 
}
