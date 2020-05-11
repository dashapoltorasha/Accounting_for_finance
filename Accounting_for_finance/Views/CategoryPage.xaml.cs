using Accounting_for_finance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Accounting_for_finance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        public CategoryPage()
        {
            InitializeComponent();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Category selectedCategory = (Category)e.SelectedItem;
            CategoryDetailPage CategoryPage = new CategoryDetailPage(selectedCategory.Id);
            CategoryPage.BindingContext = selectedCategory;
            await Navigation.PushAsync(CategoryPage);
        }
        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            Category Category = new Category();
            CategoryDetailPage CategoryPage = new CategoryDetailPage();
            CategoryPage.BindingContext = Category;
            await Navigation.PushAsync(CategoryPage);
        }
        protected override void OnAppearing()
        {
            CategoryList.ItemsSource = DbService.LoadAllCategory();
            base.OnAppearing();
        }
    }
}