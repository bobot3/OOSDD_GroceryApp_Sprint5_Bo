using Grocery.App.ViewModels;
using Grocery.Core.Models;

namespace Grocery.App.Views;

public partial class ProductCategoryView : ContentPage
{
    public ProductCategoryView(ProductCategoryViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

}
