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
    public partial class CategoryDetailPage : ContentPage
    {
        public CategoryDetailPage()
        {
            ToolbarItem save = new ToolbarItem { Text = "Сохранить" };
            save.Clicked += Save_Clicked;
            this.ToolbarItems.Add(save);
            InitializeComponent();
        }
        public Category Category { get; set; }
        public CategoryDetailPage(int id)
        {
            ToolbarItem del = new ToolbarItem { Text = "Удалить" };
            del.Clicked += Delete_Clicked;
            ToolbarItem save = new ToolbarItem { Text = "Сохранить" };
            save.Clicked += Save_Clicked;
            this.ToolbarItems.Add(del);
            this.ToolbarItems.Add(save);
            InitializeComponent();
            Category = DbService.FindCategory(id);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
                var category = (Category)BindingContext;
                if (!String.IsNullOrEmpty(category.Name))
                {
                    DbService.UpdateCategory(category);
                }
                this.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DependencyService.Get<IToast>().Show("Заполните все поля");
            }
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var category = (Category)BindingContext;
            DbService.RemoveCategory(category);
            this.Navigation.PopAsync();
        }
    }
}