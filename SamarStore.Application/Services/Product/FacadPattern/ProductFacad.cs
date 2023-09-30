using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using SamarStore.Application.Interfaces.Context;
using SamarStore.Application.Interfaces.FacadPatterns;
using SamarStore.Application.Services.Product.Commands.AddNewCategory;
using SamarStore.Application.Services.Product.Queries.GetCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamarStore.Application.Services.Product.FacadPattern
{
    public class ProductFacad : IProductFacad
    {
        //--Inject DataBase
        private readonly IDataBaseContext _context;
        public ProductFacad(IDataBaseContext context)
        {
            _context = context;
        }

        //--Inject AddNewCategoryService
        private IAddNewCategoryService _addNewCategory;
        public IAddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }

        //--Inject GetCategoryService
        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService
        {
            get
            {
                return _getCategoryService = _getCategoryService ?? new GetCategoryService(_context);   
            }
        }
    }
    
}
