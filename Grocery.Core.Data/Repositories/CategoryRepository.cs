using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;

namespace Grocery.Core.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly List<Category> categories;

        public CategoryRepository()
        {
            categories = new List<Category>
            {
                new Category(1, "Zuivel"),
                new Category(2, "Bakkerij"),
                new Category(3, "Dranken")
            };
        }

        public Task AddCategoryAsync(Category category)
        {
            categories.Add(category);
            return Task.CompletedTask;
        }

        public Task DeleteCategoryAsync(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            if (category != null)
            {
                categories.Remove(category);
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return Task.FromResult<IEnumerable<Category>>(categories);
        }

        public Task<Category?> GetCategoryByIdAsync(int id)
        {
            var category = categories.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(category);
        }

        // Deze methode is overbodig geworden, maar als je interface hem nog vereist:
        public Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            // Omdat Category geen Guid heeft, kunnen we hier altijd null teruggeven
            return Task.FromResult<Category?>(null);
        }

        public Task UpdateCategoryAsync(Category category)
        {
            var existing = categories.FirstOrDefault(c => c.Id == category.Id);
            if (existing != null)
            {
                existing.Name = category.Name;
            }
            return Task.CompletedTask;
        }
    }
}
