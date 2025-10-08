using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grocery.Core.Models;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IProductCategoryRepository
    {
        Task<IEnumerable<ProductCategory>> GetAllProductCategoriesAsync();
        Task<ProductCategory?> GetProductCategoryByIdAsync(int id);
        Task AddProductCategoryAsync(ProductCategory productCategory);
        Task UpdateProductCategoryAsync(ProductCategory productCategory);
        Task DeleteProductCategoryAsync(int id);
    }
}
