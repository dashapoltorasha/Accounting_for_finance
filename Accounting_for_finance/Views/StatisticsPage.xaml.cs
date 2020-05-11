using Accounting_for_finance.Data;
using Accounting_for_finance.Models;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Accounting_for_finance.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatisticsPage : ContentPage
    {
        public Operation Operation { get; set; }
        public Label header, label4, label3;
        public Picker picker;
        public DatePicker datePicker, datePicker2;
        public Entry amountEntry, commentsEntry;
        int a;
        DateTime d1, d2;
        public bool f = false, f2 = false;
        public StatisticsPage()
        {
            d1 = DateTime.Now;
            d2 = DateTime.Now;

            header = new Label
            {
                Text = "Выберите счет",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            picker = new Picker
            {
                Title = "Счета"
            };
            picker.Items.Add("Все счета");
            for (int i = 0; i < BillData.Bills.Count; i++)
                picker.Items.Add(BillData.Bills[i].Text);
            picker.SelectedIndex = 0;
            picker.SelectedIndexChanged += picker_SelectedIndexChanged;

            label3 = new Label { Text = "Выберите начальную дату" };
            datePicker = new DatePicker
            {
                Format = "D"
            };
            datePicker.DateSelected += datePicker_DateSelected;

            label4 = new Label { Text = "Выберите конечную дату" };
            datePicker2 = new DatePicker
            {
                Format = "D"
            };
            datePicker2.DateSelected += datePicker_DateSelected2;

            Button button = new Button
            {
                Text = "Сформировать статистику",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += OnButtonClicked;

            this.Content = new StackLayout { Children = { header, picker, label3, datePicker, label4, datePicker2, button } };
            InitializeComponent();
        }
        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            header.Text = "Вы выбрали: " + picker.Items[picker.SelectedIndex];
            f = true;
            a = picker.SelectedIndex;
        }
        public void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            label3.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
            d1 = e.NewDate;
        }

        public void datePicker_DateSelected2(object sender, DateChangedEventArgs e)
        {
            label4.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
            d2 = e.NewDate;
        }

        private async void OnButtonClicked(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            Statistic st = new Statistic(a, d1, d2);
            await Navigation.PushAsync(st);
        }
    }
}