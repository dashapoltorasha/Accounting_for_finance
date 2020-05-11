using Accounting_for_finance.Data;
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
    public partial class OperationPage : ContentPage
    {
        public OperationPage()
        {
            InitializeComponent();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Operation selectedOperation = (Operation)e.SelectedItem;
            OperationDetailPage OperationPage = new OperationDetailPage(selectedOperation);
            OperationPage.BindingContext = selectedOperation;
            await Navigation.PushAsync(OperationPage);
        }
        private async void AddItem_Clicked(object sender, EventArgs e)
        {
            Operation Operation = new Operation();
            OperationDetailPage OperationPage = new OperationDetailPage();
            OperationPage.BindingContext = Operation;
            await Navigation.PushAsync(OperationPage);
        }
        protected override void OnAppearing()
        {
            operationsList.ItemsSource = DbService.LoadAllOperations();
            base.OnAppearing();
        }
    }
}