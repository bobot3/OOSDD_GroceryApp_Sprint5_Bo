using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            productCategories = new List<ProductCategory>
            {
                new ProductCategory(1, "Melk - Zuivel", 1, 1),
                new ProductCategory(2, "Kaas - Zuivel", 2, 1),
                new ProductCategory(3, "Brood - Bakkerij", 3, 2)
            };
        }

        public Task AddProductCategoryAsync(ProductCategory productCategory)
        {
            productCategories.Add(productCategory);
            return Task.CompletedTask;
        }

        public Task DeleteProductCategoryAsync(int id)
        {
            var pc = productCategories.FirstOrDefault(p => p.Id == id);
            if (pc != null)
            {
                productCategories.Remove(pc);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return Task.FromResult<IEnumerable<ProductCategory>>(productCategories);
        }

        public Task<ProductCategory?> GetProductCategoryByIdAsync(int id)
        {
            var pc = productCategories.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(pc);
        }

        public Task UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            var existing = productCategories.FirstOrDefault(p => p.Id == productCategory.Id);
            if (existing != null)
            {
                existing.Name = productCategory.Name;
                existing.ProductId = productCategory.ProductId;
                existing.CategoryId = productCategory.CategoryId;
            }
            return Task.CompletedTask;
        }
    }
}
