using Accounting_for_finance.Data;
using Accounting_for_finance.Models;
using Accounting_for_finance.Views;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Accounting_Test.BillPageTest
{
    [TestClass]
    public class OperationDetailPageTest
    {
        [TestInitialize()]
        public void MyTestInitialize()
        {
            DbService.ClearAll();
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            DbService.RefrashDb();
        }

        [TestMethod]
        public void AddNewOperation1()
        {
            DbService.LoadTestSample();
            OperationData.Operations.Add(new Operation
            {
                date = new DateTime(2020, 3, 20),
                amount = 300,
                Comments = ""
            });
            OperationDetailPage opPage = new OperationDetailPage();

            opPage.picker.SelectedIndex = 1;
            opPage.picker2.SelectedIndex = 1;
            opPage.datePicker.DateSelected += opPage.datePicker_DateSelected;
            opPage.datePicker.Date = new DateTime(2020, 3, 20);
            opPage.amountEntry.Text = "546";
            opPage.commentsEntry.Text = "";
            Assert.AreEqual("546", opPage.amountEntry.Text);
        }
        [TestMethod]
        public void AddNewOperation2()
        {
            OperationDetailPage opPage = new OperationDetailPage();

            opPage.picker.SelectedIndex = 1;
            opPage.picker2.SelectedIndex = 1;
            opPage.datePicker.DateSelected += opPage.datePicker_DateSelected;
            opPage.datePicker.Date = new DateTime(2020, 3, 20);
            opPage.amountEntry.Text = "546";
            opPage.commentsEntry.Text = "";
        }

        [TestMethod]
        public void EditNewOperation()
        {
            DbService.AddBill(new Bill
            {
                Id=10,
                Type = true,
                Text = "Sber",
                Description = "Card",
                Balance = 15000,
                Number = "0397"
            });
            DbService.AddCategory(new Category
            {
                Id=15,
                Name = "Продукты",
                Type = true
            });
            OperationDetailPage opPage = new OperationDetailPage(new Operation
            {
                Id=16,
                date = new DateTime(2020, 3, 20),
                amount = 300,
                category=DbService.FindCategory(15),
                bill = DbService.FindBill(10),
                Comments = ""
            });

            opPage.picker.SelectedIndex = 1;
            opPage.picker2.SelectedIndex = 1;
            opPage.datePicker.DateSelected += opPage.datePicker_DateSelected;
            opPage.datePicker.Date = new DateTime(2020, 3, 20);
            opPage.amountEntry.Text = "546";
            opPage.commentsEntry.Text = "";
            Assert.AreEqual("546", opPage.amountEntry.Text);
        }

    }
}
