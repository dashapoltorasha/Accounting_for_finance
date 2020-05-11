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
    public partial class BillDetailPage : ContentPage
    {
        public Bill Bill { get; set; }
        public BillDetailPage()
        {
            ToolbarItem save = new ToolbarItem { Text = "Сохранить" };
            save.Clicked += Save_Clicked;
            this.ToolbarItems.Add(save);
            InitializeComponent();
        }
        public BillDetailPage(int id)
        {
            ToolbarItem del = new ToolbarItem { Text = "Удалить" };
            del.Clicked += Delete_Clicked;
            ToolbarItem save = new ToolbarItem { Text = "Сохранить" };
            save.Clicked += Save_Clicked;
            this.ToolbarItems.Add(del);
            this.ToolbarItems.Add(save);
            InitializeComponent();
            Bill = DbService.FindBill(id);
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
            var bill = (Bill)BindingContext;
            if (!String.IsNullOrEmpty(bill.Text))
            {
                DbService.UpdateBill(bill);
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
            var bill = (Bill)BindingContext;
            DbService.RemoveBill(bill);
            this.Navigation.PopAsync();
        }
    }
}