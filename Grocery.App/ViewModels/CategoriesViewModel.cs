using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Grocery.App.ViewModels
{
    public partial class CategoriesViewModel : ObservableObject
    {
        private readonly ICategoryService _categoryService;

        [ObservableProperty]
        private ObservableCollection<Category> categories;

        public CategoriesViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            Categories = new ObservableCollection<Category>();
            LoadCategories();
        }

        private async void LoadCategories()
        {
            if (_categoryService == null) return;

            var cats = await _categoryService.GetAllCategoriesAsync();

            Categories.Clear();
            foreach (var cat in cats)
                Categories.Add(cat);
        }


        [RelayCommand]
        private async Task SelectCategory(Category category)
        {
            if (category == null) return;

            // Zorg dat de route exact overeenkomt met wat je in AppShell hebt geregistreerd
            await Shell.Current.GoToAsync($"{nameof(ProductCategoryView)}?categoryId={category.Id}");
        }
    }
}
