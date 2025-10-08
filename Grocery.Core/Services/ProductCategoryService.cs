using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public Task AddProductCategoryAsync(ProductCategory productCategory)
        {
            return _productCategoryRepository.AddProductCategoryAsync(productCategory);
        }

        public Task DeleteProductCategoryAsync(int id)
        {
            return _productCategoryRepository.DeleteProductCategoryAsync(id);
        }

        public Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return _productCategoryRepository.GetAllProductCategoriesAsync();
        }

        public Task<ProductCategory?> GetProductCategoryByIdAsync(int id)
        {
            return _productCategoryRepository.GetProductCategoryByIdAsync(id);
        }

        public Task UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            return _productCategoryRepository.UpdateProductCategoryAsync(productCategory);
        }
    }
}
