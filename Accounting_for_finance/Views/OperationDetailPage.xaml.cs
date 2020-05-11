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
    public partial class OperationDetailPage : ContentPage
    {
        public Operation Operation { get; set; }
        public Label header, header2, textLabel1, textLabel2, label3;
        public Picker picker, picker2;
        public DatePicker datePicker;
        public Entry amountEntry, commentsEntry;
        uint a;
        bool b;
        public bool f=false, f2=false;
        public OperationDetailPage()
        {
            ToolbarItem save= new ToolbarItem { Text = "Сохранить" };
            save.Clicked += Save_Clicked;
            this.ToolbarItems.Add(save);
            textLabel1 = new Label
            {
                Text = "Сумма",
                //FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            amountEntry = new Entry { Placeholder = "amount", Text="0" };
            textLabel2 = new Label
            {
                Text = "Комментарий",
                //FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            commentsEntry = new Entry { Placeholder = "comments" };
            header = new Label
            {
                Text = "Выберите счет",
                //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            picker = new Picker
            {
                Title = "Счета"
            };
            for (int i = 0; i < BillData.Bills.Count; i++)
                picker.Items.Add(BillData.Bills[i].Text);

            picker.SelectedIndexChanged += picker_SelectedIndexChanged;

            header2 = new Label
            {
                Text = "Выберите категорию",
                //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            picker2 = new Picker
            {
                Title = "Категории"
            };
            for (int i = 0; i < CategoryData.Categorys.Count; i++)
                picker2.Items.Add(CategoryData.Categorys[i].Name);

            picker2.SelectedIndexChanged += picker2_SelectedIndexChanged;
            label3 = new Label { Text = "Выберите дату" };
            datePicker = new DatePicker
            {
                Format = "D",
            };
            datePicker.DateSelected += datePicker_DateSelected;
            InitializeComponent();
            this.Content = new StackLayout { Children = { header, picker, header2, picker2, textLabel1, amountEntry, label3, datePicker, textLabel2, commentsEntry } };
        }

        void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            header.Text = "Вы выбрали: " + picker.Items[picker.SelectedIndex];
            f = true;
        }
        void picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            header2.Text = "Вы выбрали: " + picker2.Items[picker2.SelectedIndex];
            f2 = true;
        }
        public void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            label3.Text = "Вы выбрали " + e.NewDate.ToString("dd/MM/yyyy");
        }

        public OperationDetailPage(Operation operation)
        {
            ToolbarItem del = new ToolbarItem { Text = "Удалить" };
            del.Clicked += Delete_Clicked;
            ToolbarItem save = new ToolbarItem { Text = "Сохранить" };
            save.Clicked += Save_Clicked;
            this.ToolbarItems.Add(del);
            this.ToolbarItems.Add(save);
            Operation = operation;
            if(Operation.category!=null)
                b = Operation.category.Type;
            a = Operation.amount;
            textLabel1 = new Label
            {
                Text = "Сумма",
                //FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            };
            amountEntry = new Entry { Placeholder = "amount", Text = Operation.amount.ToString() };
            textLabel2 = new Label
            {
                Text = "Комментарий",
                //FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            commentsEntry = new Entry { Placeholder = "comments", Text = Operation.Comments };
            header = new Label
            {
                Text = "Выберите счет",
                //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            picker = new Picker
            {
                Title = "Счета"
            };
            for (int i = 0; i < BillData.Bills.Count; i++)
                picker.Items.Add(BillData.Bills[i].Text);
            if(Operation.bill!=null)
                picker.SelectedIndex = Operation.bill.Id-1;
            picker.SelectedIndexChanged += picker_SelectedIndexChanged;

            header2 = new Label
            {
                Text = "Выберите категорию",
                //FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            picker2 = new Picker
            {
                Title = "Категории"
            };
            for (int i = 0; i < CategoryData.Categorys.Count; i++)
                picker2.Items.Add(CategoryData.Categorys[i].Name);
            if (Operation.category != null)
                picker2.SelectedIndex = Operation.category.Id-1;

            picker2.SelectedIndexChanged += picker2_SelectedIndexChanged;
            label3 = new Label { Text = "Выберите дату" };
            datePicker = new DatePicker
            {
                Format = "D",
            };
            datePicker.Date = Operation.date;
            datePicker.DateSelected += datePicker_DateSelected;
            InitializeComponent();
            this.Content = new StackLayout { Children = { header, picker, header2, picker2, textLabel1, amountEntry, label3, datePicker, textLabel2, commentsEntry } };
        }

        public void Save_Clicked(object sender, EventArgs e)
        {
            try
            {
            var Operation = (Operation)BindingContext;
            Operation.amount = Convert.ToUInt32(amountEntry.Text);
            Operation.bill= DbService.FindBill(picker.SelectedIndex+1);
            Operation.category = DbService.FindCategory(picker2.SelectedIndex + 1);
            Operation.Comments = commentsEntry.Text;
            Operation.date = datePicker.Date;
            if (b == true)
            {
                var bill = DbService.FindBill(Operation.bill.Id);
                bill.Balance = bill.Balance+a;
                DbService.UpdateBill(Operation.bill);
            }
            else
            {
                    var bill = DbService.FindBill(Operation.bill.Id);
                    if (bill.Balance < a)
                    {
                        bill.Balance = bill.Balance - a;
                        DbService.UpdateBill(Operation.bill);
                    }
                    else throw new Exception();
                }
            if (Operation.category.Type == true)
            {
                var bill = DbService.FindBill(Operation.bill.Id); 
                bill.Balance = bill.Balance- Operation.amount;
                DbService.UpdateBill(Operation.bill);
            }
            else
            {
                var bill = DbService.FindBill(Operation.bill.Id); 
                bill.Balance = bill.Balance+a+ Operation.amount;
                DbService.UpdateBill(Operation.bill);
            }
            DbService.UpdateOperation(Operation);
            this.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                DependencyService.Get<IToast>().Show("Заполните все поля");
            }
        }
        public void Delete_Clicked(object sender, EventArgs e)
        {
            var Operation = (Operation)BindingContext;
            Operation.amount = Convert.ToUInt32(amountEntry.Text);
            if (f == true)
                Operation.bill = DbService.FindBill(picker.SelectedIndex + 1);
            if(f2 == true)
                Operation.category = DbService.FindCategory(picker2.SelectedIndex + 1);
            Operation.Comments = commentsEntry.Text;
            Operation.date = datePicker.Date;
            DbService.RemoveOperation(Operation);
            this.Navigation.PopAsync();
        }
    }
}