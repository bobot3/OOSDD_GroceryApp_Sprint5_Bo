using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(CategoryId), "categoryId")]
    public partial class ProductCategoryViewModel : ObservableObject
    {
        private readonly IProductCategoryService _service;

        [ObservableProperty]
        private int categoryId;

        [ObservableProperty]
        private ObservableCollection<ProductCategory> productCategories;

        public ProductCategoryViewModel(IProductCategoryService service)
        {
            _service = service;
            ProductCategories = new ObservableCollection<ProductCategory>();
        }

        // Wordt automatisch aangeroepen wanneer CategoryId via QueryProperty wordt ingesteld
        partial void OnCategoryIdChanged(int value)
        {
            LoadProductCategories(value);
        }

        private async void LoadProductCategories(int categoryId)
        {
            var allCategories = await _service.GetAllProductCategoriesAsync();

            // Filter alleen de items van de geselecteerde categorie
            var filtered = allCategories.Where(pc => pc.CategoryId == categoryId);

            ProductCategories.Clear();
            foreach (var pc in filtered)
                ProductCategories.Add(pc);
        }
    }
}
