﻿using Microsoft.AspNetCore.Http;

namespace SamarStore.Application.Services.Products.Commands.AddNewProduct;

public class RequestAddNewProductDto
{
    public string Name { get; set; } = string.Empty;    
    public string Brand { get; set; } = string.Empty;   
    public string Description { get; set; } = string.Empty; 
    public int Price { get; set; }
    public int Inventory { get; set; }
    public long CategoryId { get; set; }
    public bool Displayed { get; set; }

    public List<IFormFile> Images { get; set; }
    public List<AddNewProduct_Features> Features { get; set; }

}