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
    public partial class BillsPage : ContentPage
    {
        public BillsPage()
        {
            InitializeComponent();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Bill selectedBill = (Bill)e.SelectedItem;
            BillDetailPage billPage = new BillDetailPage(selectedBill.Id);
            billPage.BindingContext = selectedBill;
            await Navigation.PushAsync(billPage);
        }
        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            BillDetailPage BillPage = new BillDetailPage();
            BillPage.BindingContext = bill;
            await Navigation.PushAsync(BillPage);
        }
        protected override void OnAppearing()
        {
            billsList.ItemsSource = DbService.LoadAllBills();
            base.OnAppearing();
        }

    }
}